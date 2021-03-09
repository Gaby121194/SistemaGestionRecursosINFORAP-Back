using AutoMapper;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Security;
using INFORAP.API.Common.Utility;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IBaseRepository<Usuario> _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityConfiguration _appSettings;
        private readonly IMailClient _mailClient;

        public UsuarioService(IBaseRepository<Usuario> userRepository,
            IMapper mapper,
            ISecurityConfiguration appSettings,
            IMailClient mailClient)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings;
            _mailClient = mailClient;
        }

        public async Task<IEnumerable<UsuarioDTO>> List(UsuarioDTO userLogged, bool isSuperUser, UsuarioFilterDTO filter = null)
        {
            IEnumerable<Usuario> entities;
            if (isSuperUser)
            {
                entities = await _userRepository.ListBy(usuario =>
                ((!filter.IdEmpresa.HasValue || usuario.IdEmpresa == filter.IdEmpresa.Value)
                && (!filter.CreationDateFrom.HasValue || usuario.CreationDate >= filter.CreationDateFrom.Value)
                 && (!filter.CreationDateTo.HasValue || usuario.CreationDate <= filter.CreationDateTo.Value)
                 && (filter.Nombre.IsNullOrEmpty() || usuario.Nombre.ToLower().Contains(filter.Nombre)
                 || usuario.Apellido.ToLower().Contains(filter.Nombre)
                 || usuario.Email.ToLower().Contains(filter.Nombre)))
                && usuario.Active == true,
                s => s.Rol,
                includeProperties => includeProperties.Empresa);

                //using (var ctx = new InfoRapContext())
                //{
                //    entities = await ctx.Usuario.Where(s => s.Active)
                //        .Include(s => s.Rol)
                //        .Include(s => s.Empresa)
                //        .ToListAsync();
                //}

            }
            else
            {
                entities = await _userRepository.ListBy(usuario =>
                usuario.IdEmpresa == userLogged.IdEmpresa &&
                ((!filter.CreationDateFrom.HasValue || usuario.CreationDate >= filter.CreationDateFrom.Value)
                 && (!filter.CreationDateTo.HasValue || usuario.CreationDate <= filter.CreationDateTo.Value)
                 && (filter.Nombre.IsNullOrEmpty() || usuario.Nombre.ToLower().Contains(filter.Nombre)
                 || usuario.Apellido.ToLower().Contains(filter.Nombre)
                 || usuario.Email.ToLower().Contains(filter.Nombre)))
                && usuario.Active == true,
                includeProperties => includeProperties.Rol,
                includeProperties => includeProperties.Empresa);
            }
            var dtos = _mapper.Map<IEnumerable<UsuarioDTO>>(entities);
            return dtos;
        }
        public async Task<UsuarioDTO> GetBy(int id)
        {
            var entity = await _userRepository.GetBy(usuario => usuario.Id == id && usuario.Active == true, s => s.Rol);
            return _mapper.Map<UsuarioDTO>(entity);
        }
        public async Task<UsuarioDTO> GetIfNotExpiredBy(int id)
        {
            var entity = await _userRepository.GetBy(usuario => usuario.Id == id
            && usuario.Active == true
            && usuario.ExpiredSession != true, s => s.Rol);

            return entity != null ? _mapper.Map<UsuarioDTO>(entity) : null;
        }

        public async Task<UsuarioDTO> GetBy(string userName)
        {
            var entity = await _userRepository.GetBy(usuario => usuario.Email == userName, s => s.Rol);
            return _mapper.Map<UsuarioDTO>(entity);
        }
        public async Task<UsuarioDTO> Update(UsuarioDTO loggedUser, int id, UsuarioDTO dto, bool markAsExpired = false)
        {
            var entity = await _userRepository.GetById(id);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = loggedUser.Id;
            entity.Nombre = dto.Nombre;
            entity.Apellido = dto.Apellido;
            entity.Active = dto.Active.HasValue ? dto.Active.Value : entity.Active;
            if (loggedUser.Id == id && !string.IsNullOrEmpty(dto.Password))
            {
                entity.Contrasenia = dto.Password.ToHash();
            }
            entity.ExpiredSession = markAsExpired;
            entity.IdRol = dto.IdRol;
            entity = await _userRepository.Update(id, entity);
            return _mapper.Map<UsuarioDTO>(entity);
        }

        public async Task<UsuarioDTO> Insert(UsuarioDTO loggedUser, UsuarioDTO dto)
        {
            try
            {
                var tempPsw = Guid.NewGuid().ToString().Substring(0, 8);
                var entity = _mapper.Map<Usuario>(dto);
                entity.UpdateDate = entity.CreationDate = DateTime.Now;
                entity.UpdateUserId = entity.CreationUserId = loggedUser.Id;
                entity.Active = true;
                entity.Contrasenia = tempPsw.ToHash();
                entity = await _userRepository.Insert(entity);
                dto = _mapper.Map<UsuarioDTO>(entity);
                var nombre = dto.Nombre + ", " + dto.Apellido;
                var body = $"Estimado {nombre}:" + Environment.NewLine +
                   "Le damos la bienvenida a Inforap" + Environment.NewLine +
                    "Se le ha asignado un usuario de acceso a Inforap"
                    + Environment.NewLine +
                    $"  - Su usuario es: {dto.Email}" + Environment.NewLine +
                    $"  - Su contraseña es: {tempPsw} ";
                _mailClient.Send(dto.Email, nombre, "Bienvenido a InfoRap", body);
                return dto;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task UpdatePassword(int id, string password)
        {
            var entity = await _userRepository.GetById(id);
            entity.Contrasenia = password.ToHash();
            entity.UpdateDate = DateTime.Now;
            entity.ExpiredSession = true;
            await _userRepository.Update(id, entity);
        }

        public async Task Remove(int id, UsuarioDTO loggedUser)
        {
            var user = await _userRepository.GetById(id);
            user.Active = false;
            user.UpdateDate = DateTime.Now;
            user.UpdateUserId = loggedUser.Id;
            user.ExpiredSession = true;
            await _userRepository.Update(id, user);
        }


        public async Task<bool> Exists(string username)
        {
            return await _userRepository.Any(s => s.Email == username);
        }

    }
}
