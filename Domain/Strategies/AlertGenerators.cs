using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Strategies
{
    public interface IAlertGenerator
    {
        TipoReglaEnum TipoRegla { get; }
        Task GenerateAlerts(Requisito requisito);
    }

    public class ReglaTipoUnoAlertGenerator : IAlertGenerator
    {
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;

        public ReglaTipoUnoAlertGenerator(IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<RecursoAsignado> recursoAsignadoRepository, IBaseRepository<Alerta> alertaRepository)
        {
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _alertaRepository = alertaRepository;
        }
        public TipoReglaEnum TipoRegla => TipoReglaEnum.TipoUno;       
        public async Task GenerateAlerts(Requisito requisito)
        {
            try
            {
                var recursos = await _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.Active == true
                             && s.Active == true
                             && s.IdServicio == requisito.IdServicio
                             && s.IdRecursoNavigation.IdTipoRecurso == requisito.IdTipoRecurso1
                             && (s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
                             || (requisito.IdTipoRecursoMaterial1.HasValue && s.IdRecursoNavigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial1.Value))
                             ),
                             i => i.IdRecursoNavigation,
                             i => i.IdRecursoNavigation.RecursoMaterial,
                             i => i.IdRecursoNavigation.RecursoHumano,
                             i => i.IdServicioNavigation);

                foreach (var recursoFor in recursos)
                {
                    var rrAsignados = await _recursoAsignadoRepository.ListBy(s => s.Active == true
                    && s.IdRecurso1 == recursoFor.IdRecurso
                    && s.IdRecurso2Navigation != null
                    && s.FechaAsignado.HasValue
                   // && s.FechaAsignado >= DateTime.Now.AddDiff((UTiempoEnum)requisito.IdUtiempo.Value,-1 * requisito.Periodicidad.Value)
                    && s.IdRecurso2Navigation.Active == true
                    && s.IdRecurso2Navigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial2.Value)
                    ,i => i.IdRecurso2Navigation,
                    i => i.IdRecurso2Navigation.RecursoMaterial);
                    var rrAsignado = rrAsignados.FirstOrDefault(s => s.FechaAsignado.Value.AddDiff((UTiempoEnum)requisito.IdUtiempo.Value, requisito.Periodicidad.Value)>= DateTime.Now);
                    if (rrAsignado == null)
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                        && s.Active == true
                        && s.IdRequisito == requisito.Id);
                        if (alert != null) continue;

                        alert = new Alerta();
                        alert.Active = true;
                        alert.UpdateDate = alert.CreationDate = DateTime.Now;
                        alert.UpdateUserId = alert.CreationUserId = 1;
                        alert.Descripcion = requisito.Descripcion;
                        alert.IdRecurso1 = recursoFor.IdRecurso;
                        alert.IdRequisito = requisito.Id;
                        await _alertaRepository.Insert(alert);

                    }
                    else
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                         && s.Active == true
                         && s.IdRequisito == requisito.Id);
                        if (alert == null) continue;
                        alert.Active = false;
                        alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                        alert.IdRecurso2 = rrAsignado.IdRecurso2;
                        await _alertaRepository.Update(alert);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }

    public class ReglaTipoDosAlertGenerator : IAlertGenerator
    {
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;

        public ReglaTipoDosAlertGenerator(IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<RecursoAsignado> recursoAsignadoRepository, IBaseRepository<Alerta> alertaRepository)
        {
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _alertaRepository = alertaRepository;
        }

        public TipoReglaEnum TipoRegla => TipoReglaEnum.TipoDos;
        public async Task GenerateAlerts(Requisito requisito)
        {
            try
            {
                var recursos = await _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.Active == true
                             && s.Active == true
                             && s.IdServicio == requisito.IdServicio
                             && s.IdRecursoNavigation.IdTipoRecurso == requisito.IdTipoRecurso1
                             && (s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
                             || (requisito.IdTipoRecursoMaterial1.HasValue && s.IdRecursoNavigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial1.Value))
                             ),
                             i => i.IdRecursoNavigation,
                             i => i.IdRecursoNavigation.RecursoMaterial,
                             i => i.IdRecursoNavigation.RecursoHumano,
                             i => i.IdServicioNavigation);

                foreach (var recursoFor in recursos)
                {
                    var rrAsignado = await _recursoAsignadoRepository.GetBy(s => s.Active == true
                    && s.IdRecurso1 == recursoFor.IdRecurso
                    && s.IdRecurso2Navigation != null
                    && s.FechaAsignado.HasValue
                    && s.IdRecurso2Navigation.Active == true
                    && s.IdRecurso2Navigation.RecursoRenovable.Any(p => p.Active == true && p.IdTipoRecursoRenovable == requisito.IdTipoRecursoRenovable.Value && p.FechaVencimiento >= DateTime.Now)
                    , i => i.IdRecurso2Navigation,
                    i => i.IdRecurso2Navigation.RecursoRenovable);
                    if (rrAsignado == null)
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                        && s.Active == true
                        && s.IdRequisito == requisito.Id);
                        if (alert != null) continue;

                        alert = new Alerta();
                        alert.Active = true;
                        alert.UpdateDate = alert.CreationDate = DateTime.Now;
                        alert.UpdateUserId = alert.CreationUserId = 1;
                        alert.Descripcion = requisito.Descripcion;
                        alert.IdRecurso1 = recursoFor.IdRecurso;
                        alert.IdRequisito = requisito.Id;
                        await _alertaRepository.Insert(alert);

                    }
                    else
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                         && s.Active == true
                         && s.IdRequisito == requisito.Id);
                        if (alert == null) continue;
                        alert.Active = false;
                        alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                        alert.IdRecurso2 = rrAsignado.IdRecurso2;
                        await _alertaRepository.Update(alert);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
    public class ReglaTipoTresAlertGenerator : IAlertGenerator
    {
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;
        public TipoReglaEnum TipoRegla => TipoReglaEnum.TipoTres;

        public ReglaTipoTresAlertGenerator(IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<RecursoAsignado> recursoAsignadoRepository, IBaseRepository<Alerta> alertaRepository)
        {
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _alertaRepository = alertaRepository;
        }

        public async Task GenerateAlerts(Requisito requisito)
        {
            try
            {
                var recursos = await _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.Active == true
                             && s.Active == true
                             && s.IdServicio == requisito.IdServicio
                             && s.IdRecursoNavigation.IdTipoRecurso == requisito.IdTipoRecurso1
                             && (s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
                             || (requisito.IdTipoRecursoMaterial1.HasValue && s.IdRecursoNavigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial1.Value))
                             ),
                             i => i.IdRecursoNavigation,
                             i => i.IdRecursoNavigation.RecursoMaterial,
                             i => i.IdRecursoNavigation.RecursoHumano,
                             i => i.IdServicioNavigation);

                foreach (var recursoFor in recursos)
                {
                    var rrAsignado = await _recursoAsignadoRepository.GetBy(s => s.Active == true
                    && s.IdRecurso1 == recursoFor.IdRecurso
                    && s.IdRecurso2Navigation != null
                    && s.FechaAsignado.HasValue
                    && s.IdRecurso2Navigation.Active == true
                    && s.IdRecurso2Navigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial2.Value)
                    , i => i.IdRecurso2Navigation,
                    i => i.IdRecurso2Navigation.RecursoMaterial);
                    if (rrAsignado == null)
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                        && s.Active == true
                        && s.IdRequisito == requisito.Id);
                        if (alert != null) continue;

                        alert = new Alerta();
                        alert.Active = true;
                        alert.UpdateDate = alert.CreationDate = DateTime.Now;
                        alert.UpdateUserId = alert.CreationUserId = 1;
                        alert.Descripcion = requisito.Descripcion;
                        alert.IdRecurso1 = recursoFor.IdRecurso;
                        alert.IdRequisito = requisito.Id;
                        await _alertaRepository.Insert(alert);

                    }
                    else
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                         && s.Active == true
                         && s.IdRequisito == requisito.Id);
                        if (alert == null) continue;
                        alert.Active = false;
                        alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                        alert.IdRecurso2 = rrAsignado.IdRecurso2;
                        await _alertaRepository.Update(alert);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
    public class ReglaTipoCuatroAlertGenerator : IAlertGenerator
    {
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;
        public TipoReglaEnum TipoRegla => TipoReglaEnum.TipoCuatro;

        public ReglaTipoCuatroAlertGenerator(IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<RecursoAsignado> recursoAsignadoRepository, IBaseRepository<Alerta> alertaRepository)
        {
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _alertaRepository = alertaRepository;
        }

        public async Task GenerateAlerts(Requisito requisito)
        {
            try
            {
                var recursos = await _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.Active != true
                             && s.Active != true
                             && s.IdServicio == requisito.IdServicio
                             && s.IdRecursoNavigation.IdTipoRecurso == requisito.IdTipoRecurso1
                             && requisito.IdTipoRecursoMaterial1.HasValue && s.IdRecursoNavigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial1.Value),
                             i => i.IdRecursoNavigation,
                             i => i.IdRecursoNavigation.RecursoMaterial,
                             i => i.IdRecursoNavigation.RecursoHumano,
                             i => i.IdServicioNavigation);

                foreach (var recursoFor in recursos)
                {

                    if (recursoFor.IdRecursoNavigation.CreationDate.AddDiff((UTiempoEnum)requisito.IdUtiempo.Value,requisito.Periodicidad.Value) >= recursoFor.IdRecursoNavigation.RemovalDate.Value)
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                        && s.Active == true
                        && s.IdRequisito == requisito.Id);
                        if (alert != null) continue;

                        alert = new Alerta();
                        alert.Active = true;
                        alert.UpdateDate = alert.CreationDate = DateTime.Now;
                        alert.UpdateUserId = alert.CreationUserId = 1;
                        alert.Descripcion = requisito.Descripcion;
                        alert.IdRecurso1 = recursoFor.IdRecurso;
                        alert.IdRequisito = requisito.Id;
                        await _alertaRepository.Insert(alert);
                    }
                    else continue;

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
    public class ReglaTipoCincoAlertGenerator : IAlertGenerator
    {
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<FueraServicio> _fueraServicioRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;
        public TipoReglaEnum TipoRegla => TipoReglaEnum.TipoCinco;

        public ReglaTipoCincoAlertGenerator(IBaseRepository<ServicioRecurso> servicioRecursoRepository, IBaseRepository<FueraServicio> fueraServicioRepository, IBaseRepository<Alerta> alertaRepository)
        {
            _servicioRecursoRepository = servicioRecursoRepository;
            _fueraServicioRepository = fueraServicioRepository;
            _alertaRepository = alertaRepository;
        }

        public async Task GenerateAlerts(Requisito requisito)
        {
            try
            {
                var recursos = await _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.Active == true
                             && s.Active == true
                             && s.IdServicio == requisito.IdServicio
                             && s.IdRecursoNavigation.IdTipoRecurso == requisito.IdTipoRecurso1
                             && (requisito.IdTipoRecursoMaterial1.HasValue && s.IdRecursoNavigation.RecursoMaterial.Any(p => p.Active == true && p.IdTipoRecursoMaterial == requisito.IdTipoRecursoMaterial1.Value))
                             ,
                             i => i.IdRecursoNavigation,
                             i => i.IdRecursoNavigation.RecursoMaterial,
                             i => i.IdServicioNavigation);

                foreach (var recursoFor in recursos)
                {
                    var fueraServicios = await _fueraServicioRepository.ListBy(s => s.Active == true
                    && s.IdRecursoMaterial == recursoFor.IdRecursoNavigation.RecursoMaterial.FirstOrDefault().Id);
                    var fueraServicio = fueraServicios.FirstOrDefault(s => s.FechaInicio.Value.AddDiff((UTiempoEnum)requisito.IdUtiempo, requisito.Periodicidad.Value) <= DateTime.Now);
                    if (fueraServicio != null)
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                        && s.Active == true
                        && s.IdRequisito == requisito.Id);
                        if (alert != null) continue;

                        alert = new Alerta();
                        alert.Active = true;
                        alert.UpdateDate = alert.CreationDate = DateTime.Now;
                        alert.UpdateUserId = alert.CreationUserId = 1;
                        alert.Descripcion = requisito.Descripcion;
                        alert.IdRecurso1 = recursoFor.IdRecurso;
                        alert.IdRequisito = requisito.Id;
                        await _alertaRepository.Insert(alert);

                    }
                    else
                    {
                        var alert = await _alertaRepository.GetBy(s => s.IdRecurso1.Value == recursoFor.IdRecurso
                         && s.Active == true
                         && s.IdRequisito == requisito.Id);
                        if (alert == null) continue;
                        alert.Active = false;
                        alert.UpdateDate = alert.FechaFin = alert.RemovalDate = DateTime.Now;
                        await _alertaRepository.Update(alert);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }


}
