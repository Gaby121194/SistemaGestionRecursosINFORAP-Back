using AutoMapper;
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
    public class UbicacionService :IUbicacionService
    {
        private readonly IBaseRepository<Ubicacion> _ubicacionRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Provincia> _provinciaRepository;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoRepository;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<Recurso> _recursoRepository;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;

        public UbicacionService(
            IBaseRepository<Ubicacion> ubicacionRepository, 
            IBaseRepository<Provincia> provinciaRepository, 
            IBaseRepository<ServicioRecurso> servicioRecursoRepository,
            IBaseRepository<Recurso> recursoRepository,
            IBaseRepository<StockRecursoMaterial> stockRepository,
            IBaseRepository<RecursoAsignado> recursoAsignadoRepository,
            IMapper mapper, 
            IBaseRepository<StockRecursoMaterial> stockrecursoRepository
            )
        {
            _ubicacionRepository = ubicacionRepository;
            _mapper = mapper;
            _provinciaRepository = provinciaRepository;
            _stockRecursoRepository = stockrecursoRepository;
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoRepository = recursoRepository;
            _stockRepository = stockRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;

        }

        public async Task<UbicacionDTO> Create(UsuarioDTO userLogged, UbicacionDTO dto)
        {
            var entity = _mapper.Map<Ubicacion>(dto);
            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;
            entity.IdEmpresa = userLogged.IdEmpresa;
            entity = await _ubicacionRepository.Insert(entity);
            return _mapper.Map<UbicacionDTO>(entity);
        }

        public async Task<UbicacionDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _ubicacionRepository.GetBy(s => s.Id == id, s => s.Empresa);

            if (userLogged.IdEmpresa == entity.IdEmpresa ) 
            {
                var dto = _mapper.Map<UbicacionDTO>(entity);
                return dto;
            }
            return null;
        }

        public async Task<IEnumerable<UbicacionDTO>> List(UsuarioDTO userlogged, UbicacionFilterDTO filter = null)
        {
            IEnumerable<Ubicacion> entities;

            entities = await _ubicacionRepository.ListBy(ubicacion =>
                    (
                        (ubicacion.IdEmpresa == userlogged.IdEmpresa) &&
                        (!filter.CreationDateFrom.HasValue || ubicacion.CreationDate >= filter.CreationDateFrom.Value) &&
                        (!filter.CreationDateTo.HasValue || ubicacion.CreationDate <= filter.CreationDateTo.Value) &&

                        (
                            filter.Name.IsNullOrEmpty()||
                            ubicacion.Localidad.ToLower().Contains(filter.Name) ||
                            ubicacion.Numero.ToLower().Contains(filter.Name) ||
                            ubicacion.Departamento.ToLower().Contains(filter.Name) ||
                            ubicacion.Calle.ToLower().Contains(filter.Name) ||
                            ubicacion.Provincia.Nombre.ToLower().Contains(filter.Name) ||
                            ubicacion.Referencia.ToLower().Contains(filter.Name)
                        )
                    ) &&
                    ubicacion.Active == true,
                    s => s.Empresa
            );

            var dtos = _mapper.Map<IEnumerable<UbicacionDTO>>(entities);

            foreach (var item in dtos)
            {
                item.DescripcionProvincia = (await _provinciaRepository.GetById(item.IdProvincia)).Nombre;
            }

            return dtos;
        }

        public async Task<bool> Remove(UsuarioDTO loggedUser, int id)
        {
            var entity = await _ubicacionRepository.GetBy(s => s.Id == id, s=> s.Empresa);
            bool recursoAsignado = await _recursoAsignadoRepository.Any(s => s.IdUbicacion == entity.Id && s.Active == true);
            bool recursoUbicacion = await _recursoRepository.Any(s => s.IdUbicacion == entity.Id && s.Active == true);
            bool servicioRecurso = await _servicioRecursoRepository.Any(s => s.IdUbicacion == entity.Id && s.Active == true);
            bool stockUbicacion = await _stockRecursoRepository.Any(s => s.Active == true && s.IdUbicacion == entity.Id);
            if ( !recursoUbicacion && !stockUbicacion && !recursoAsignado && !servicioRecurso)
            {
                entity.Active = false;
                entity.RemovalDate = DateTime.Now;
                entity.UpdateUserId = loggedUser.Id;
                await _ubicacionRepository.Update(id, entity);
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<UbicacionDTO> Update(UsuarioDTO loggedUser,  int id, UbicacionDTO dto)
        {
            var entity = _mapper.Map<Ubicacion>(dto);

            if (entity.IdEmpresa == loggedUser.IdEmpresa )
            {

                entity.UpdateDate = DateTime.Now;
                entity.UpdateUserId = loggedUser.Id;
                var original = await _ubicacionRepository.GetById(id);
                entity.CreationDate = original.CreationDate;
                entity.CreationUserId = original.CreationUserId;
                entity.Active = original.Active;

                entity = await _ubicacionRepository.Update(id, entity);
                return _mapper.Map<UbicacionDTO>(entity);
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _ubicacionRepository.Any(s =>
                (id == null || s.Id != id.Value) &&
                s.Referencia.Trim() == name.Trim() &&
                s.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            ); 
        }

        public async Task<IEnumerable<UbicacionDTO>> ListByRecursoMaterial(UsuarioDTO userLogged, int id)
        {
            var ubicacionesDeStocks = 
                (
                    await _stockRecursoRepository.ListBy(s => s.Active && s.IdRecursoMaterial == id) 
                    //me traigo todos los stocks perteneceientes a un recurso material
                ).Select(s => s.IdUbicacion);
                    // me quedo con solo los idubicaciones

            var entities = await _ubicacionRepository.ListBy(ubicacion =>
               ubicacion.Active &&
               ubicacion.IdEmpresa == userLogged.IdEmpresa && 
               !ubicacionesDeStocks.Contains(ubicacion.Id)  
            );

            return _mapper.Map<IEnumerable<UbicacionDTO>>(entities);
        }
    }
}

