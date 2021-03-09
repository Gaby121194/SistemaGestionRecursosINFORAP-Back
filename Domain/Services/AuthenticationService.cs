using AutoMapper;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace INFORAP.API.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBaseRepository<Usuario> _userRepository;
        private readonly IBaseRepository<Permiso> _permisoRepository;
        private readonly IBaseRepository<PermisoRol> _permisoRolRepository;
        private readonly IBaseRepository<PermisoControladorAccion> _permisoControladorRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityConfiguration _appSettings;
        public UsuarioDTO Usuario { get; set; }
        public AuthenticationService(IBaseRepository<Usuario> userRepository,
            IMapper mapper,
            IBaseRepository<Permiso> permisoRepository, IBaseRepository<PermisoRol> permisoRolRepository,
            IBaseRepository<PermisoControladorAccion> permisoControladorRepository,
        ISecurityConfiguration appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings;
            _permisoRolRepository = permisoRolRepository;
            _permisoRepository = permisoRepository;
            _permisoControladorRepository = permisoControladorRepository;
        }

        public async Task<AuthenticationTokenDTO> Authenticate(AuthenticationDTO dto)
        {
            try
            {
                var entity = await _userRepository.GetBy(usuario =>
           usuario.Active == true
           && usuario.Email == dto.UserName
           && usuario.Contrasenia == dto.Password.ToHash(),
           //INCLUDES: 
           s => s.Rol,
           s => s.Rol.PermisoRol,
           s => s.Empresa
           );
                if (entity == null) return null;
                if (entity.ExpiredSession == true)
                {
                    entity.ExpiredSession = false;
                    await _userRepository.Update(entity);
                }
                var isSuperUser = false;
                if (entity.Rol != null)
                {
                    isSuperUser = _permisoRolRepository.ListBy(s => s.RolId == entity.IdRol
                    && s.Active == true
                    && s.Permiso.IsSuperUser == true, p => p.Permiso).GetAwaiter().GetResult().Count() > 0;
                }
                IEnumerable<PermisoDTO> permisos = new List<PermisoDTO>();
                IEnumerable<ControladorDTO> views = new List<ControladorDTO>();
                if (entity.IdRol.HasValue)
                {
                    permisos = GetPermisos(entity.IdRol.Value);
                    views = await GetViews(entity.IdRol.Value);

                }
                return generateJwtToken(_mapper.Map<UsuarioDTO>(entity), permisos,views, isSuperUser);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        private AuthenticationTokenDTO generateJwtToken(UsuarioDTO user, IEnumerable<PermisoDTO> permisos, IEnumerable<ControladorDTO> views, bool IsSuperUser)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString())
                ,new Claim("user", user.Serialize())
                , new Claim("permisos",permisos.Serialize())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationTokenDTO
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = user,
                IsSuperUser = IsSuperUser,
                Permisos = permisos,
                Views = views
            };
        }

        public async Task<IEnumerable<ControladorDTO>> GetViews(int idRol)
        {
            var permisos = GetPermisos(idRol).Select(s=> s.Id).ToList();
            var controllers = _permisoControladorRepository.ListBy(s => permisos.Contains(s.PermisoId) && s.Controlador.Active,s => s.Controlador).Result.GroupBy(s=>s.Controlador).Select(s=>s.Key).ToList();
            return _mapper.Map<IEnumerable<ControladorDTO>>(controllers);        
        }

        private IEnumerable<PermisoDTO> GetPermisos(int idRol)
        {
            var permisos = _permisoRolRepository.ListBy(s => 
            s.Active == true
            && s.Permiso.Active == true && s.Rol.Active == true 
            && s.RolId == idRol, s => s.Permiso, s => s.Rol).GetAwaiter().GetResult().GroupBy(s => s.Permiso).Select(s => s.Key);
            return _mapper.Map<IEnumerable<PermisoDTO>>(permisos);
        }

    }
}
