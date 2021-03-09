using AutoMapper;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static INFORAP.API.DTOs.RolDTO;

namespace INFORAP.API.Domain.Services
{
    public class RolService : IRolService
    {
        private readonly IBaseRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PermisoRol> _permisoRolRepository;

        public RolService(IMapper mapper, IBaseRepository<Rol> rolRepository, IBaseRepository<PermisoRol> permisoRolRepository)
        {
            _mapper = mapper;
            _rolRepository = rolRepository; ;
            _permisoRolRepository = permisoRolRepository;
        }

        public async Task<RolDTO> Create(RolDTO dto, UsuarioDTO userLogged)
        {
            var rol = _mapper.Map<Rol>(dto);
            rol.Active = true;
            rol.CreationDate = DateTime.Now;
            rol.UpdateDate = DateTime.Now;
            rol.CreationUserId = userLogged.Id;
            rol.UpdateUserId = userLogged.Id;
            rol.IdEmpresa = userLogged.IdEmpresa;
            rol = await _rolRepository.Insert(rol);

            foreach (var item in dto.Permisos)
            {
                PermisoRol entity = new PermisoRol
                {
                    RolId = rol.Id,
                    PermisoId = (int)item,
                    Active = true,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreationUserId = userLogged.Id,
                    UpdateUserId = userLogged.Id
                };
                await _permisoRolRepository.Insert(entity);
            }

            var rolDTO = _mapper.Map<RolDTO>(rol);
            var permisosRoles = await _permisoRolRepository.ListBy(s => s.RolId == rol.Id);
            rolDTO.Permisos = permisosRoles.Select(s => s.Id).ToArray();
            return rolDTO;
        }

        public async Task<RolDTO> GetById(int id)
        {
            var rol = await _rolRepository.GetById(id);
            var rolDTO = _mapper.Map<RolDTO>(rol);
            var permisosRoles = await _permisoRolRepository.ListBy(s => s.RolId == rol.Id && s.Active == true);
            rolDTO.Permisos = permisosRoles.Select(s => s.PermisoId).ToArray();

            return rolDTO;
        }

        public async Task<IEnumerable<RolDTO>> List()
        {          
            var entity = await _rolRepository.ListBy(s => s.Active == true, includeProperties => includeProperties.InverseUsuario);
            var dtos = _mapper.Map<IEnumerable<RolDTO>>(entity);
            return dtos;
        }

        public async Task<IEnumerable<RolDTO>> List(UsuarioDTO userLogged, bool isSuperUser, RolFilterDTO filter = null)
        {
            IEnumerable<Rol> entities;
            var prueba = filter;
            if (isSuperUser) {
                entities = await _rolRepository.ListBy(rol =>
                       (
                          (!filter.IdEmpresa.HasValue || rol.IdEmpresa == filter.IdEmpresa.Value) &&
                           (!filter.CreationDateFrom.HasValue || rol.CreationDate >= filter.CreationDateFrom.Value) &&
                           (!filter.CreationDateTo.HasValue || rol.CreationDate <= filter.CreationDateTo.Value) &&

                           (filter.Datos.IsNullOrEmpty() || rol.Nombre.ToLower().Contains(filter.Datos) ||
                           rol.Descripcion.ToLower().Contains(filter.Datos))
                       ) &&

                       rol.Active == true,
                       rol => rol.Empresa
                       );
                    }
           
            else
            {
                entities = await _rolRepository.ListBy(rol =>
                rol.IdEmpresa == userLogged.IdEmpresa &&
                ((!filter.CreationDateFrom.HasValue || rol.CreationDate >= filter.CreationDateFrom.Value)
                 && (!filter.CreationDateTo.HasValue || rol.CreationDate <= filter.CreationDateTo.Value)
                 && (filter.Datos.IsNullOrEmpty() || rol.Nombre.ToLower().Contains(filter.Datos)
                 || rol.Descripcion.ToLower().Contains(filter.Datos)))
                && rol.Active == true,
                includeProperties => includeProperties.Empresa
                );
            }
            var dtos = _mapper.Map<IEnumerable<RolDTO>>(entities);
            return dtos;
        }

        public async Task<IEnumerable<RolDTO>> ListByEmpresaId(int id)
        {
            var entity = await _rolRepository.ListBy(s=>s.IdEmpresa == id && s.Active == true);
            var dtos = _mapper.Map<IEnumerable<RolDTO>>(entity);
            return dtos.OrderBy(s => s.Nombre);
        }

        public async Task Remove(int id)
        {
            var rol = await _rolRepository.GetById(id);
            rol.Active = false;
            rol.RemovalDate = DateTime.Now;
            await _rolRepository.Update(id, rol);

            var permisosRoles = await _permisoRolRepository.ListBy(s => s.RolId == id);
            foreach (var item in permisosRoles)
            {
                item.Active = false;
                item.RemovalDate = DateTime.Now;

                await _permisoRolRepository.Update(item.Id, item);
            }
        }

        public async Task<bool> IsSuperUser(int id)
        {
            var res = await _permisoRolRepository.GetBy(s => s.RolId == id && s.Permiso.IsSuperUser == true,
                s => s.Permiso);
            return res != null;
        }

        public async Task<RolDTO> Update(int id, RolDTO dto, UsuarioDTO userLogged)
        {
            Rol entity = _mapper.Map<Rol>(dto);
            var oldentity = await _rolRepository.GetById(id);
            entity.UpdateDate = DateTime.Now;
            entity.CreationDate = oldentity.CreationDate;
            entity.UpdateUserId = userLogged.Id;
            entity.CreationUserId = userLogged.Id;
            entity = await _rolRepository.Update(id, entity);
            var dtos = _mapper.Map<RolDTO>(entity);

            var permisosRolesAntiguos = await _permisoRolRepository.ListBy(s => s.RolId == id);

            foreach (var item in permisosRolesAntiguos)
            {
                await _permisoRolRepository.Remove(item.Id);
            }

            foreach (var item in dto.Permisos)
            {
                PermisoRol permisoRol = new PermisoRol
                {
                    RolId = id,
                    PermisoId = (int)item,
                    Active = true,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreationUserId = userLogged.Id,
                    UpdateUserId = userLogged.Id
                };
                await _permisoRolRepository.Insert(permisoRol);
            }

            return dtos;
        }

        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _rolRepository.Any(s => (id == null || s.Id != id.Value) &&
                s.IdEmpresa == userLogged.IdEmpresa &&
                ((s.Nombre == name.Trim()) | (s.Descripcion == name.Trim())) &&
                s.Active == true
            );


        }



    }
}
