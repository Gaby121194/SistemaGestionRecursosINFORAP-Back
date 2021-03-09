using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
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
    public class MenuService : IMenuService
    {
        private readonly IBaseRepository<PermisoControladorAccion> _permisoContAccRepository;
        private readonly IBaseRepository<PermisoRol> _permisoRolRepository;
        private readonly IMapper _mapper;

        public MenuService(IBaseRepository<PermisoControladorAccion> permisoContAccRepository, IBaseRepository<PermisoRol> permisoRolRepository, IMapper mapper)
        {
            _permisoContAccRepository = permisoContAccRepository;
            _permisoRolRepository = permisoRolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ControladorDTO>> ListBy(int rolId)
        {
            var result = new List<ControladorDTO>();
            var permisos = await _permisoRolRepository.ListBy(s => s.RolId == rolId,
                s => s.Permiso);
            var permControlador = await _permisoContAccRepository
                .ListBy(s => permisos.Select(s => s.PermisoId).Contains(s.PermisoId)
                && (s.AccionId == null || s.AccionId == AccionEnum.List.ToInt()),
                x => x.Controlador);
            var groupData = permControlador.GroupBy(s => s.Controlador, x => x.Controlador);
            return _mapper.Map<IEnumerable<ControladorDTO>>(groupData.Select(x => x.Key).ToList());

        }


    }
}
