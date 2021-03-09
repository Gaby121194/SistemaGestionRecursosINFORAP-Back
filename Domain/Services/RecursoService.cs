using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class RecursoService : IRecursoService
    {
        private readonly IBaseRepository<Recurso> _recursoRepository;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<Servicio> _servicioRepository;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoMaterialRepository;
        private readonly IBaseRepository<RecursoMaterial> _recursoMaterialRepository;
        private readonly IMapper _mapper;

        public RecursoService(IBaseRepository<Recurso> recursoRepository, IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<Servicio> servicioRepository, IBaseRepository<StockRecursoMaterial> stockRecursoMaterialRepository, IBaseRepository<RecursoMaterial> recursoMaterialRepository, IMapper mapper)
        {
            _recursoRepository = recursoRepository;
            _servicioRecursoRepository = servicioRecursoRepository;
            _servicioRepository = servicioRepository;
            _stockRecursoMaterialRepository = stockRecursoMaterialRepository;
            _recursoMaterialRepository = recursoMaterialRepository;
            _mapper = mapper;
        }

        public async Task<RecursoDTO> Create(RecursoDTO dto)
        {
            var entity = _mapper.Map<Recurso>(dto);
            entity.CreationDate = DateTime.Now;
            entity.Active = true;
            entity.FechaAlta = DateTime.Now;
            entity = await _recursoRepository.Insert(entity);
            return _mapper.Map<RecursoDTO>(entity);
        }

        public async Task<RecursoDTO> GetById(int id)
        {
            var entity = await _recursoRepository.GetById(id);
            var dto = _mapper.Map<RecursoDTO>(entity);
            return dto;
        }

        public async Task<IEnumerable<RecursoDTO>> List()
        {
            var entities = await _recursoRepository.ListBy(null);
            var dtos = _mapper.Map<IEnumerable<RecursoDTO>>(entities);
            return dtos;
        }

        public async Task Remove(int id)
        {
            var entity = await _recursoRepository.GetById(id);
            entity.Active = false;
            entity.RemovalDate = DateTime.Now;
            entity.FechaBaja = DateTime.Now;
            await _recursoRepository.Update(id, entity);
        }

        public async Task<RecursoDTO> Update(int id, RecursoDTO dto)
        {

            var entity = _mapper.Map<Recurso>(dto);
            entity.UpdateDate = DateTime.Now;

            entity = await _recursoRepository.Update(id, entity);
            return _mapper.Map<RecursoDTO>(entity);
        }

        public async Task<IEnumerable<ServicioRecursoDTO>> ListFromService(int IdServicio, ServicioRecursoFilterDTO filter, UsuarioDTO currUser)
        {
            var result = new List<ServicioRecursoDTO>();
            var rrhh = await _servicioRecursoRepository.ListBy(s =>
            s.Active == true && s.IdServicio == IdServicio
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
             && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa,
            s => s.IdRecursoNavigation,
            s => s.IdRecursoNavigation.IdTipoRecursoNavigation,
            s => s.IdRecursoNavigation.RecursoHumano);
            var rrmat = await _servicioRecursoRepository.ListBy(s =>
            s.Active == true && s.IdServicio == IdServicio
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()
             && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa,
            s => s.IdRecursoNavigation,
            s => s.IdUbicacionNavigation,
            s => s.IdRecursoNavigation.IdTipoRecursoNavigation,
            s => s.IdRecursoNavigation.RecursoMaterial);

            if (rrhh.Any())
            {
                result.AddRange(rrhh.Select(s => new ServicioRecursoDTO
                {
                    Recurso = new RecursoDTO
                    {
                        Id = s.IdRecurso,
                        Descripcion = s.IdRecursoNavigation.RecursoHumano.FirstOrDefault().Apellido + ", " + s.IdRecursoNavigation.RecursoHumano.FirstOrDefault().Nombre + " - " + s.IdRecursoNavigation.RecursoHumano.FirstOrDefault().Cuil,
                        CreationDate = s.IdRecursoNavigation.CreationDate
                    },
                    TipoRecurso = _mapper.Map<TipoRecursoDTO>(s.IdRecursoNavigation.IdTipoRecursoNavigation),
                    FechaAsignado = s.FechaAsignado,
                    Id = s.Id,
                    FechaDesasignado = s.FechaDesasignado,
                    IdRecurso = s.IdRecurso,
                    IdUbicacion = s.IdUbicacion,
                    IdServicio = s.IdServicio
                }).ToList());
            }
            if (rrmat.Any())
            {
                result.AddRange(rrmat.Select(s => new ServicioRecursoDTO
                {
                    Recurso = new RecursoDTO
                    {
                        Id = s.IdRecurso,
                        Descripcion = s.IdRecursoNavigation.RecursoMaterial.FirstOrDefault().Marca + ", " + s.IdRecursoNavigation.RecursoMaterial.FirstOrDefault().Modelo + (s.IdUbicacionNavigation != null ? " - "+ s.IdUbicacionNavigation.Referencia :""),
                        CreationDate = s.IdRecursoNavigation.CreationDate
                    },
                    TipoRecurso = _mapper.Map<TipoRecursoDTO>(s.IdRecursoNavigation.IdTipoRecursoNavigation),
                    FechaAsignado = s.FechaAsignado,
                    Id = s.Id,
                    FechaDesasignado = s.FechaDesasignado,
                    IdRecurso = s.IdRecurso,
                    IdUbicacion = s.IdUbicacion,
                    IdServicio = s.IdServicio
                }).ToList());
            }

            return result.Where(s=>
            (!filter.FechaAsignadoFrom.HasValue || s.FechaAsignado>= filter.FechaAsignadoFrom.Value)
            &&(!filter.FechaAsignadoTo.HasValue || s.FechaAsignado <= filter.FechaAsignadoTo.Value)
            &&(!filter.IdTipoRecurso.HasValue || s.TipoRecurso.Id == filter.IdTipoRecurso.Value)
            ).OrderBy(x => x.Id);
        }

        public async Task InsertServicioRecurso(int idServicio, ServicioRecursoDTO dto, UsuarioDTO currUser)
        {
            if (!await _servicioRepository.Any(s => s.Id == idServicio && s.IdEmpresa == currUser.IdEmpresa)) throw new NotFoundException();
            var entity = _mapper.Map<ServicioRecurso>(dto);
            entity.Active = true;
            entity.UpdateDate = entity.FechaAsignado = entity.CreationDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = currUser.Id;
            entity.IdServicio = idServicio;
            entity = await _servicioRecursoRepository.Insert(entity);
            if (dto.IdUbicacion.HasValue && dto.Recurso.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt())
            {
                var rMat = await _recursoMaterialRepository.GetBy(s => s.IdRecurso == dto.IdRecurso, s=> s.IdRecursoNavigation);
                if (rMat == null)
                {
                    await _servicioRecursoRepository.Remove(entity);
                    throw new NotFoundException();
                }
                var stock = await _stockRecursoMaterialRepository.GetBy(s => s.IdRecursoMaterial == rMat.Id
                 && s.IdUbicacion == dto.IdUbicacion.Value && s.CantidadDisponible > 0);
                if (stock == null)
                {
                    await _servicioRecursoRepository.Remove(entity);
                    throw new NotFoundException();
                }
                stock.CantidadDisponible -= 1;
                await _stockRecursoMaterialRepository.Update(stock.Id, stock);

                if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == rMat.Id && s.CantidadDisponible > 0))
                {

                    rMat.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                    await _recursoMaterialRepository.Update(rMat);
                }
                else
                {
                    rMat.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                    await _recursoMaterialRepository.Update(rMat);
                }
            }
            else
            {
                var recurso = await _recursoRepository.GetBy(s => s.Id == entity.IdRecurso, r=>r.RecursoHumano, r=>r.RecursoMaterial);
                if (recurso != null
                     && ((recurso.RecursoMaterial.Any() && recurso.RecursoMaterial.FirstOrDefault().Multiservicio != true)
                    || (recurso.RecursoHumano.Any() && recurso.RecursoHumano.FirstOrDefault().Multiservicio != true)))
                {
                    recurso.UpdateDate = DateTime.Now;
                    recurso.UpdateUserId = currUser.Id;
                    recurso.IdEstado = EstadosEnum.Asignado.ToInt();
                    await _recursoRepository.Update(recurso);
                }
            }

        }
        public async Task DeleteServicioRecurso(int idServicioRecurso, UsuarioDTO currUser)
        {
            var entity = await _servicioRecursoRepository.GetBy(s => s.Active
            && s.Id == idServicioRecurso
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecursoNavigation.Active == true
            && s.IdServicioNavigation.Active == true,
            s => s.IdRecursoNavigation,
            s => s.IdRecursoNavigation.RecursoMaterial,
            s => s.IdServicioNavigation);
            if (entity == null) throw new NotFoundException();
            entity.Active = false;
            entity.UpdateDate = entity.FechaDesasignado = entity.RemovalDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = currUser.Id;
            entity = await _servicioRecursoRepository.Update(entity);
            if (entity.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()
                && entity.IdUbicacion.HasValue)
            {
                var rMat = entity.IdRecursoNavigation.RecursoMaterial.FirstOrDefault();
                if (rMat != null && rMat.Stockeable == true)
                {
                    var stock = await _stockRecursoMaterialRepository.GetBy(s => s.IdRecursoMaterial == rMat.Id
                     && s.IdUbicacion == entity.IdUbicacion);
                    if (stock != null)
                    {
                        stock.CantidadDisponible += 1;
                        await _stockRecursoMaterialRepository.Update(stock);

                        if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == rMat.Id && s.CantidadDisponible > 0))
                        {

                            rMat.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                            await _recursoMaterialRepository.Update(rMat);
                        }
                        else
                        {
                            rMat.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                            await _recursoMaterialRepository.Update(rMat);
                        }
                    }

                }
            }
            else
            {
                var recurso = await _recursoRepository.GetBy(s => s.Id == entity.IdRecurso, r => r.RecursoHumano, r => r.RecursoMaterial);
                
                if (recurso != null 
                    && ((recurso.RecursoMaterial.Any() && recurso.RecursoMaterial.FirstOrDefault().Multiservicio != true) 
                    || (recurso.RecursoHumano.Any() && recurso.RecursoHumano.FirstOrDefault().Multiservicio != true)) )
                {
                    recurso.UpdateDate = DateTime.Now;
                    recurso.UpdateUserId = currUser.Id;
                    recurso.IdEstado = EstadosEnum.Disponible.ToInt();
                    await _recursoRepository.Update(recurso);
                }
            }

        }
        public async Task<IEnumerable<RecursoServicioDTO>> ListFromResource(int IdRecurso, RecursoServicioFilterDTO filter, UsuarioDTO currUser)
        {
            var result = new List<RecursoServicioDTO>();
            var services = await _servicioRecursoRepository.ListBy(s =>
            s.Active == true && (s.IdRecurso == IdRecurso || s.IdServicioNavigation.IdRecursoHumano1Navigation.IdRecurso == IdRecurso)
            && s.IdServicioNavigation.IdEmpresa == currUser.IdEmpresa,
            s => s.IdServicioNavigation,
            s => s.IdServicioNavigation.IdClienteNavigation,
            s=> s.IdServicioNavigation.IdRecursoHumano1Navigation);

            if (services.Any())
            {
                result.AddRange(services.Select(s => new RecursoServicioDTO
                {
                    Servicio = new ServicioDTO
                    {
                        Id = s.IdServicio,
                        Nombre = s.IdServicioNavigation.Nombre,
                        NroContrato = s.IdServicioNavigation.NroContrato,
                        Objetivo = s.IdServicioNavigation.Objetivo,
                        FechaInicio = s.IdServicioNavigation.FechaInicio,
                        FechaFin = s.IdServicioNavigation.FechaFin,
                        FechaBaja = s.IdServicioNavigation.FechaBaja,
                        MotivoBaja = s.IdServicioNavigation.MotivoBaja,
                        IdMotivoBajaServicio = s.IdServicioNavigation.IdMotivoBajaServicio,
                        IdCliente = s.IdServicioNavigation.IdCliente,
                        IdEmpresa = s.IdServicioNavigation.IdEmpresa,
                        IdRecursoHumano1 = s.IdServicioNavigation.IdRecursoHumano1,
                        IdRecursoHumano2 = s.IdServicioNavigation.IdRecursoHumano2,
                        CreationDate = s.IdServicioNavigation.CreationDate,
                    },
                    FechaAsignado = s.FechaAsignado,
                    Id = s.Id,
                    FechaDesasignado = s.FechaDesasignado,
                    IdRecurso = s.IdRecurso,
                    IdUbicacion = s.IdUbicacion,
                    IdServicio = s.IdServicio,
                    Cliente = s.IdServicioNavigation.IdClienteNavigation.RazonSocial,
                    Encargado= s.IdServicioNavigation.IdRecursoHumano1Navigation.Apellido + ", " + s.IdServicioNavigation.IdRecursoHumano1Navigation.Nombre
                }).ToList());
            }
            return result.Where(s =>
            (!filter.FechaAsignadoFrom.HasValue || s.FechaAsignado >= filter.FechaAsignadoFrom.Value)
            && (!filter.FechaAsignadoTo.HasValue || s.FechaAsignado <= filter.FechaAsignadoTo.Value)
            // Aca falta agregar filters
            ).OrderBy(x => x.Id);
        }

    }
}
