using AutoMapper;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class PermisoService : IPermisoService
    {
        private readonly IBaseRepository<Permiso> _permisoRepository;
        private readonly IBaseRepository<PermisoRol> _permisoRolRepository;
        private readonly IBaseRepository<PermisoControladorAccion> _permisoControladorRepository;
        private readonly IBaseRepository<Controlador> _controladorRepository;

        private readonly IMapper _mapper;

        public PermisoService(IBaseRepository<Permiso> permisoRepository, IBaseRepository<PermisoRol> permisoRolRepository, IBaseRepository<PermisoControladorAccion> permisoControladorRepository, IBaseRepository<Controlador> controladorRepository, IMapper mapper)
        {
            _permisoRepository = permisoRepository;
            _permisoRolRepository = permisoRolRepository;
            _permisoControladorRepository = permisoControladorRepository;
            _controladorRepository = controladorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermisoDTO>> List()
        {
            return _mapper.Map<IEnumerable<PermisoDTO>>(await _permisoRepository.ListBy(s => s.IsSuperUser == false));
        }
        public async Task<IEnumerable<PermisoDTO>> List(PermisoFilterDTO filter,bool all = false, bool onlyActive = false)
        {
            var entities = await _permisoRepository.ListBy(s => (!onlyActive || s.Active) && (all || s.IsSuperUser == false)
            && (string.IsNullOrEmpty(filter.Nombre) || s.NombrePermiso.Contains(filter.Nombre) || s.DescripcionPermiso.Contains(filter.Nombre))
            && (!filter.CreationDateFrom.HasValue || (filter.CreationDateFrom.Value <= s.CreationDate))
            && (!filter.CreationDateTo.HasValue || (filter.CreationDateTo.Value >= s.CreationDate))
            );
            return _mapper.Map<IEnumerable<PermisoDTO>>(entities);
        }
        public async Task<PermisoDTO> GetBy(int id)
        {
            var entity = await _permisoRepository.GetBy(s => s.Id == id, s => s.PermisoControladorAccion);
            if (entity == null) throw new NotFoundException();
            var dto = _mapper.Map<PermisoDTO>(entity);
            if (entity.PermisoControladorAccion.Any())
            {
                dto.ControllersIds = entity.PermisoControladorAccion.Select(s => s.ControladorId).ToArray();
            }
            return dto;
        }

        public async Task<PermisoDTO> Insert(PermisoDTO dto, UsuarioDTO currUser)
        {
            var entity = _mapper.Map<Permiso>(dto);
            entity.UpdateDate = entity.CreationDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = currUser.Id;
            entity.Active = true;
            entity.IsSuperUser = false;
            entity.PermisoControladorAccion = dto.ControllersIds.Select(s => new PermisoControladorAccion { ControladorId = s, Permiso = entity }).ToList();
            entity = await _permisoRepository.Insert(entity);
            return _mapper.Map<PermisoDTO>(entity);
        }
        public async Task<PermisoDTO> Update(PermisoDTO dto, int id, UsuarioDTO currUser)
        {
            var entity = await _permisoRepository.GetBy(s => s.Id == id, s => s.PermisoControladorAccion);
            if (entity == null) throw new NotFoundException();
            await _permisoControladorRepository.RemoveRange(entity.PermisoControladorAccion);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.PermisoControladorAccion = dto.ControllersIds.Select(s => new PermisoControladorAccion { ControladorId = s, Permiso = entity }).ToList();
            entity = await _permisoRepository.Update(entity);
            return _mapper.Map<PermisoDTO>(entity);
        }

        public async Task<PermisoDTO> Disable(int id, UsuarioDTO currUser)
        {
            var entity = await _permisoRepository.GetBy(s => s.Id == id && s.IsSuperUser != true);
            if (entity == null) throw new NotFoundException();
            entity.UpdateDate = entity.RemovalDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Active = false;
            entity = await _permisoRepository.Update(entity);
            return _mapper.Map<PermisoDTO>(entity);
        }
        public async Task<PermisoDTO> Enable(int id, UsuarioDTO currUser)
        {
            var entity = await _permisoRepository.GetBy(s => s.Id == id && s.IsSuperUser != true);
            if (entity == null) throw new NotFoundException();
            entity.UpdateDate  = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Active = true;
            entity = await _permisoRepository.Update(entity);
            return _mapper.Map<PermisoDTO>(entity);
        }
        public async Task<bool> IsSuperUser(int rolId)
        {
            var perRol = await _permisoRolRepository.GetBy(s => s.Active == true && s.RolId == rolId && s.Permiso.IsSuperUser == true,
                // includes
                x => x.Permiso);
            return perRol != null;
        }
        public async Task<bool> Exist(string nombrePermiso, int? id = null)
        {
            return await _permisoRepository.Any(s => s.Active == true && s.NombrePermiso == nombrePermiso && (id == null || s.Id != id));
        }

    }
}
