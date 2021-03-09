using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class AlertaService : IAlertaService
    {

        private readonly IBaseRepository<Alerta> _alertaRepository;
        private readonly IBaseRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public AlertaService(IBaseRepository<Alerta> alertaRepository, IBaseRepository<Usuario> usuarioRepository, IMapper mapper)
        {
            _alertaRepository = alertaRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<int> CountAlertsFor(UsuarioDTO currUser)
        {
            var alerts = await this._alertaRepository.ListBy(s => s.Active
            && s.IdRequisitoNavigation.IdServicioNavigation.IdRecursoHumano1.Value == currUser.IdRecursoHumano.Value, s => s.IdRequisitoNavigation,
            s => s.IdRequisitoNavigation.IdServicioNavigation,
            s => s.IdRequisitoNavigation.IdServicioNavigation.IdRecursoHumano1Navigation);
            return alerts.Count();
        }

        public async Task<IEnumerable<AlertaServicioDTO>> ListAlertsFor(UsuarioDTO currUser)
        {
            if (!currUser.IdRecursoHumano.HasValue) return null;
            var alertServices = new List<AlertaServicioDTO>();
            var alerts = await this._alertaRepository.ListBy(s => s.Active
            && s.IdRequisitoNavigation.IdServicioNavigation.IdRecursoHumano1.Value == currUser.IdRecursoHumano.Value,
            s=>s.IdRequisitoNavigation,
            s=>s.IdRequisitoNavigation.IdServicioNavigation,
            s=>s.IdRequisitoNavigation.IdServicioNavigation.IdRecursoHumano1Navigation,
            s=>s.IdRequisitoNavigation.IdServicioNavigation.IdClienteNavigation,
            s=>s.IdRequisitoNavigation.IdTipoRecurso1Navigation,
            s=>s.IdRequisitoNavigation.IdTipoRecursoMaterial1Navigation,
            s=>s.IdRequisitoNavigation.IdTipoRecursoMaterial2Navigation,
            s=>s.IdRequisitoNavigation.IdTipoRecursoRenovableNavigation,
            s=>s.IdRecurso1Navigation,
            s=>s.IdRecurso1Navigation.RecursoMaterial,
            s=>s.IdRecurso1Navigation.RecursoHumano         
            );

            var alertsGroupedByService = alerts.GroupBy(k => k.IdRequisitoNavigation.IdServicioNavigation, v => v);

            foreach (var item in alertsGroupedByService.ToDictionary(k=>k.Key,v=>v.ToList()))
            {
                var service = item.Key;
                if (service == null) continue;
                var alService = new AlertaServicioDTO();
                alService.Servicio = _mapper.Map<ServicioDTO>(service);
                var alertsGroupedByRequisito = item.Value.GroupBy(k => k.IdRequisitoNavigation, v => v).ToDictionary(k => k.Key, v => v.ToList());
                foreach (var alRequisito in alertsGroupedByRequisito)
                {
                    var alertDto = new AlertaDTO();
                    var dtoRequisito = _mapper.Map<RequisitoDTO>(alRequisito.Key);
                    dtoRequisito.TranscripcionRegla = GetDescription(alRequisito.Key);
                    alertDto.Requisito = dtoRequisito;
                    var alertsGroupedByResources = alRequisito.Value.GroupBy(k=>k.IdRecurso1Navigation,v=>v).Where(s=>s.Key.Active == true).Select(s=>s.Key).ToList();
                    foreach (var resource in alertsGroupedByResources)
                    {
                        var alertDate = alerts.FirstOrDefault(s => s.IdRequisito == alertDto.Requisito.Id && s.IdRecurso1 == resource.Id)?.CreationDate;
                        var resourceDto = _mapper.Map<RecursoDTO>(resource);
                        if (resource.RecursoHumano.Any())
                        {
                            var rrhh = resource.RecursoHumano.FirstOrDefault();
                            resourceDto.Descripcion = $"{rrhh.Apellido}, {rrhh.Nombre} - {rrhh.Cuil}";
                            resourceDto.CreationDate = alertDate;
                            alertDto.Recursos.Add(resourceDto);
                        }else if (resource.RecursoMaterial.Any())
                        {
                            var rrMat = resource.RecursoMaterial.FirstOrDefault();
                            resourceDto.Descripcion = $"{rrMat.Marca}, {rrMat.Modelo}";
                            resourceDto.CreationDate = alertDate;
                            alertDto.Recursos.Add(resourceDto);
                        }
                    }
                    alService.Alertas.Add(alertDto);
                }
                alertServices.Add(alService);
            }
            return alertServices;
        }



        private string GetDescription(Requisito requisito)
        {
            var req1 = "";
            switch (requisito.IdTipoRegla)
            {
                case 1:
                    {
                        req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                        return $"Cada { req1 }, debe tener asignado {requisito.IdTipoRecursoMaterial2Navigation.Descripcion} cada {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                     }
                case 2:
                    {
                        req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                        return $"Cada { req1 }, debe tener asignado y vigente {requisito.IdTipoRecursoRenovableNavigation.Descripcion}";
                    }
                case 3:
                    {
                        req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                        return  $"Cada { req1 }, debe tener asignado {requisito.IdTipoRecursoMaterial2Navigation.Descripcion}";
                    }
                case 4:
                    {
                        req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                        return $"Cada { req1 }, debe tener un ciclo de vida superior a {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                    }
                case 5:
                    {
                        req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                        return $"Cada { req1 }, no debe estar fuera de servicio por mas de {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                        
                    }
                default:
                    return "";
            }
        }
    }
}
