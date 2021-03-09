using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.Domain.Strategies;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace INFORAP.API.Domain.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IBaseRepository<Servicio> _servicioRepository;
        private readonly IBaseRepository<MotivoBajaServicio> _motivoBajaRepository;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoMaterialoRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<RecursoHumano> _recursoHumanoRepository;
        private readonly IBaseRepository<Alerta> _alertRepository;

        public ServicioService(IBaseRepository<Servicio> servicioRepository, IBaseRepository<MotivoBajaServicio> motivoBajaRepository, IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<StockRecursoMaterial> stockRecursoMaterialoRepository, IMapper mapper, IBaseRepository<RecursoHumano> recursoHumanoRepository, IBaseRepository<Alerta> alertRepository)
        {
            _servicioRepository = servicioRepository;
            _motivoBajaRepository = motivoBajaRepository;
            _servicioRecursoRepository = servicioRecursoRepository;
            _stockRecursoMaterialoRepository = stockRecursoMaterialoRepository;
            _mapper = mapper;
            _recursoHumanoRepository = recursoHumanoRepository;
            _alertRepository = alertRepository;
        }

        public async Task<IEnumerable<ServicioDTO>> ListBy(int idEmpresa, ServicioFilterDTO filter)
        {
            var entities = await _servicioRepository.ListBy(s => s.IdEmpresa == idEmpresa &&
            /*FILTROS*/
            (filter.Nombre.IsNullOrEmpty() || s.Nombre.Contains(filter.Nombre) || s.NroContrato.ToString().Contains(filter.Nombre))
            && (filter.FechaInicioFrom == null || (s.FechaInicio >= filter.FechaInicioFrom.Value))
            && (filter.FechaInicioTo == null || (s.FechaInicio <= filter.FechaInicioTo.Value))
            && (filter.FechaFinFrom == null || (s.FechaFin >= filter.FechaFinFrom.Value))
            && (filter.FechaFinTo == null || (s.FechaFin <= filter.FechaFinTo.Value)),
            s => s.IdClienteNavigation);
            return _mapper.Map<IEnumerable<ServicioDTO>>(entities);
        }

        public async Task<ServicioDTO> GetBy(int id)
        {
            var entity = await _servicioRepository.GetBy(s => s.Id == id);
            return _mapper.Map<ServicioDTO>(entity);
        }

        public async Task<ServicioDTO> Create(ServicioDTO dto, UsuarioDTO user)
        {
            var entity = _mapper.Map<Servicio>(dto);
            entity.UpdateDate = entity.CreationDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = user.Id;
            entity.IdEmpresa = user.IdEmpresa;
            entity.Active = true;
            entity = await _servicioRepository.Insert(entity);
            var rrhh = await _recursoHumanoRepository.GetBy(s => s.Id == entity.IdRecursoHumano1, r => r.IdRecursoNavigation);
            if (rrhh.Multiservicio != true)
            {
                rrhh.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                await _recursoHumanoRepository.Update(rrhh);
            }
            return _mapper.Map<ServicioDTO>(entity);
        }

        public async Task<ServicioDTO> Update(int id, ServicioDTO dto, UsuarioDTO user)
        {
            var entity = await this._servicioRepository.GetBy(s => s.Id == id);
            if (entity.IdRecursoHumano1 != dto.IdRecursoHumano1)
            {
                var oldRrhh = await _recursoHumanoRepository.GetBy(s => s.Id == entity.IdRecursoHumano1, r => r.IdRecursoNavigation);
                if (oldRrhh.Multiservicio != true)
                {
                    oldRrhh.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                    await _recursoHumanoRepository.Update(oldRrhh);
                }
                var nwRrhh = await _recursoHumanoRepository.GetBy(s => s.Id == dto.IdRecursoHumano1, r => r.IdRecursoNavigation);
                if (nwRrhh.Multiservicio != true)
                {
                    nwRrhh.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                    await _recursoHumanoRepository.Update(nwRrhh);
                }
            }
            entity.FechaInicio = dto.FechaInicio;
            entity.FechaFin = dto.FechaFin;
            entity.IdCliente = dto.IdCliente;
            entity.IdRecursoHumano1 = dto.IdRecursoHumano1;
            entity.Nombre = dto.Nombre;
            entity.Objetivo = dto.Objetivo;
            entity.NroContrato = dto.NroContrato;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = user.Id;

            entity = await _servicioRepository.Update(id, entity);

            return _mapper.Map<ServicioDTO>(entity);
        }
        public async Task Remove(int id, int idMotivoBaja, string observaciones, UsuarioDTO user)
        {
            var servicio = await _servicioRepository.GetById(id);
            var motivo = await _motivoBajaRepository.GetById(idMotivoBaja);
            servicio.FechaBaja = servicio.RemovalDate = servicio.UpdateDate = DateTime.Now;
            servicio.UpdateUserId = user.Id;
            servicio.Active = false;
            servicio.MotivoBaja = observaciones;
            servicio.IdMotivoBajaServicio = idMotivoBaja;
            await _servicioRepository.Update(id, servicio);
            var ssRecursos = await _servicioRecursoRepository.ListBy(s => s.IdServicio == id && s.Active == true,
                s => s.IdRecursoNavigation,
                s => s.IdRecursoNavigation.RecursoMaterial);
            foreach (var item in ssRecursos)
            {
                item.Active = false;
                item.FechaDesasignado = item.UpdateDate = item.RemovalDate = DateTime.Now;
                item.UpdateUserId = user.Id;
            }
            await _servicioRecursoRepository.UpdateRange(ssRecursos);
            var ssRecursosMat = ssRecursos.Where(s => s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()).ToList();
            foreach (var item in ssRecursosMat)
            {
                var rrMat = item.IdRecursoNavigation.RecursoMaterial.FirstOrDefault();
                if (rrMat != null && rrMat.Stockeable == true)
                {
                    var stock = await _stockRecursoMaterialoRepository.GetBy(s => s.Active == true
                    && s.IdRecursoMaterial == rrMat.Id
                    && s.IdUbicacion == item.IdUbicacion);
                    stock.CantidadDisponible += 1;
                    await _stockRecursoMaterialoRepository.Update(stock);
                }
            }
            var alerts = await _alertRepository.ListBy(s => s.Active == true
            && s.IdRequisitoNavigation.IdServicio == id, s => s.IdRequisitoNavigation);
            foreach (var alert in alerts)
            {
                alert.Active = false;
                alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                await _alertRepository.Update(alert);
            }
        }   
        public async Task RemoveAsEnding(int id)
        {
            var servicio = await _servicioRepository.GetById(id);
            
            servicio.FechaBaja = servicio.RemovalDate = servicio.UpdateDate = DateTime.Now;
            servicio.Active = false;
            servicio.MotivoBaja = MotivoBajaServicioEnum.FechaCumplida.GetDescription();
            servicio.IdMotivoBajaServicio = MotivoBajaServicioEnum.FechaCumplida.ToInt();
            await _servicioRepository.Update(id, servicio);
            var ssRecursos = await _servicioRecursoRepository.ListBy(s => s.IdServicio == id && s.Active == true,
                s => s.IdRecursoNavigation,
                s => s.IdRecursoNavigation.RecursoMaterial);
            foreach (var item in ssRecursos)
            {
                item.Active = false;
                item.FechaDesasignado = item.UpdateDate = item.RemovalDate = DateTime.Now;
             }
            await _servicioRecursoRepository.UpdateRange(ssRecursos);
            var ssRecursosMat = ssRecursos.Where(s => s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()).ToList();
            foreach (var item in ssRecursosMat)
            {
                var rrMat = item.IdRecursoNavigation.RecursoMaterial.FirstOrDefault();
                if (rrMat != null && rrMat.Stockeable == true)
                {
                    var stock = await _stockRecursoMaterialoRepository.GetBy(s => s.Active == true
                    && s.IdRecursoMaterial == rrMat.Id
                    && s.IdUbicacion == item.IdUbicacion);
                    stock.CantidadDisponible += 1;
                    await _stockRecursoMaterialoRepository.Update(stock);
                }
            }
            var alerts = await _alertRepository.ListBy(s => s.Active == true
          && s.IdRequisitoNavigation.IdServicio == id, s => s.IdRequisitoNavigation);
            foreach (var alert in alerts)
            {
                alert.Active = false;
                alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                await _alertRepository.Update(alert);
            }

        }



        public async Task<int> GenerateContractNumber(int idEmpresa)
        {
            var entities = await _servicioRepository.ListBy(s => s.IdEmpresa == idEmpresa && s.NroContrato.HasValue);
            if (entities.Count() == 0) return 1;
            return entities.Max(s => s.NroContrato.Value) + 1;
        }
        public async Task<bool> Exists(string name, int idEmpresa, int? id = null)
        {
            return await _servicioRepository.Any(s => s.IdEmpresa == idEmpresa &&
                (id == null || s.Id != id.Value) &&
                (s.Nombre == name || (name.IsInteger() && s.NroContrato == Convert.ToInt32(name))) &&
                s.Active == true
            );
        }

        public async Task<IEnumerable<CantidadRecursosAgrupadosMesDTO>> GetHumanResourcesGroupedByMonths(DateTime from, DateTime to, int idServicio, UsuarioDTO currUser)
        {
            if (from >= to) throw new BadRequestException("Invalid range");
            var _to = to.AddMonths(1);
            to = to.AddDays(1);
            var service = await _servicioRepository.GetBy(s => s.Active
            && s.IdEmpresa == currUser.IdEmpresa
            && s.Id == idServicio
            && s.FechaFin > from );
            var result = new List<CantidadRecursosAgrupadosMesDTO>();
            if (service == null) return result;
            if (from < service.FechaInicio)
            {
                from = service.FechaInicio.Value;
            }
            var servRrhh = await _servicioRecursoRepository.ListBy(s =>
            s.IdServicio == idServicio
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt(),
            s => s.IdRecursoNavigation);
            if (!servRrhh.Any()) return result;
            var _from = from.AddMonths(1);
            while (_from <= _to)
            {
                var quantity = servRrhh.Count(s => s.CreationDate >= from
              && s.CreationDate <= _from && (s.FechaDesasignado == null || s.FechaDesasignado.Value > _from));
                result.Add(new CantidadRecursosAgrupadosMesDTO { Anio = _from.AddMonths(-1).Year, Mes = _from.AddMonths(-1).Month, Cantidad = quantity });
                _from = _from.AddMonths(1);
            }
            return result;
        }
        public async Task<IEnumerable<CantidadServiciosActivosMesDTO>> GetActiveServicesGroupedByMonths(DateTime from, DateTime to, UsuarioDTO currUser)
        {
            var _to = to.AddMonths(1);
            to = to.AddDays(1);
            if (from >= to) throw new BadRequestException("Invalid range");
            var services = await _servicioRepository.ListBy(s =>
             s.IdEmpresa == currUser.IdEmpresa
            && s.FechaInicio >= from && s.FechaInicio <= to);
            var result = new List<CantidadServiciosActivosMesDTO>();
            if (services == null) return result;
            var _from = from.AddMonths(1);
            while (_from < _to)
            {
                var quantity = services.Count(s => s.FechaInicio >= from && s.FechaInicio <= _from
                && (s.RemovalDate == null || s.RemovalDate.Value > _from));
                result.Add(new CantidadServiciosActivosMesDTO { Anio = _from.AddMonths(-1).Year, Mes = _from.AddMonths(-1).Month, Cantidad = quantity });
                _from = _from.AddMonths(1);
            }
            return result;
        }
        public async Task<ServiciosActivosInactivosDTO> GetServiciosActivosInactivos(DateTime from, DateTime to, UsuarioDTO currUser)
        {
            to = to.AddDays(1);
            if (from >= to) throw new BadRequestException("Invalid range");
            var services = await _servicioRepository.ListBy(s =>
             s.IdEmpresa == currUser.IdEmpresa
          && !s.RemovalDate.HasValue ||( s.RemovalDate.Value >= from && s.RemovalDate.Value <= to));
            var result = new ServiciosActivosInactivosDTO();
            result.Total = services.Count();
            result.Activos = result.Total > 0 ? services.Count(s => s.Active == true) / (decimal)result.Total : 0;
            result.Inactivos = result.Total > 0 ? services.Count(s => s.Active != true) / (decimal)result.Total : 0;
            return result;
        }
        public async Task<ServiciosInactivosMotivosDTO> GetServiciosInactivosMotivos(DateTime from, DateTime to, UsuarioDTO currUser)
        {
            if (from >= to) throw new BadRequestException("Invalid range");
            to = to.AddDays(1);
            var services = await _servicioRepository.ListBy(s =>
             s.IdEmpresa == currUser.IdEmpresa && s.RemovalDate.HasValue
            && s.RemovalDate.Value >= from && s.RemovalDate.Value <= to);
            var result = new ServiciosInactivosMotivosDTO();
            result.Total = services.Count();
            result.FechaCumplida = result.Total > 0 ? services.Count(s => s.IdMotivoBajaServicio == MotivoBajaServicioEnum.FechaCumplida.ToInt()) / (decimal)result.Total : 0;
            result.DecisionCliente = result.Total > 0 ? services.Count(s => s.IdMotivoBajaServicio == MotivoBajaServicioEnum.DecisionCliente.ToInt()) / (decimal)result.Total : 0;
            result.DecisionPropia = result.Total > 0 ? services.Count(s => s.IdMotivoBajaServicio == MotivoBajaServicioEnum.DecisionPropia.ToInt()) / (decimal)result.Total : 0;
            return result;
        }

    }
}

