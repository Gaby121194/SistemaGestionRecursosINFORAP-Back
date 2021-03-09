using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class RequisitoService : IRequisitoService
    {
        private readonly IBaseRepository<Requisito> _requisitoRepository;
        private readonly IBaseRepository<TipoRegla> _tipoReglaRepository;
        private readonly IBaseRepository<Servicio> _servicioRepository;
        private readonly IBaseRepository<Alerta> _alertaRepository;
        private readonly IMapper _mapper;

        public RequisitoService(IBaseRepository<Requisito> requisitoRepository, IBaseRepository<TipoRegla> tipoReglaRepository, IBaseRepository<Servicio> servicioRepository, IBaseRepository<Alerta> alertaRepository, IMapper mapper)
        {
            _requisitoRepository = requisitoRepository;
            _tipoReglaRepository = tipoReglaRepository;
            _servicioRepository = servicioRepository;
            _alertaRepository = alertaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RequisitoDTO>> ListBy(int idServicio, int idEmpresa)
        {
            var entities = await _requisitoRepository.ListBy(s => s.Active == true
            && s.IdServicioNavigation.IdEmpresa == idEmpresa
            && s.IdServicio == idServicio,
            s => s.IdServicioNavigation,
            s=> s.IdTipoRecurso1Navigation,
            s=> s.IdTipoRecurso2Navigation,
            s=> s.IdTipoRecursoMaterial1Navigation,
            s=> s.IdTipoRecurso2Navigation,
            s=> s.IdTipoRecursoMaterial2Navigation,
            s=> s.IdTipoRecursoRenovableNavigation
            );

             return AddTranscripcionRegla(entities);
        }

        public async Task<RequisitoDTO> Insert(int idServicio, RequisitoDTO dto, UsuarioDTO currUser)
        {
            if (!(await _servicioRepository.Any(s => s.Id == idServicio && s.IdEmpresa == currUser.IdEmpresa)))
                throw new NotFoundException();
            var entity = _mapper.Map<Requisito>(dto);
            entity.UpdateDate = entity.CreationDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = currUser.Id;
            entity.Active = true;
            entity.IdServicio = idServicio;
            return _mapper.Map<RequisitoDTO>(await _requisitoRepository.Insert(entity));
        }

        public async Task Remove(int idRequisito, UsuarioDTO currUser)
        {

            var entity = await _requisitoRepository.GetBy(s => s.Id == idRequisito
            && s.IdServicioNavigation.IdEmpresa == currUser.IdEmpresa,
            s => s.IdServicioNavigation);
            entity.RemovalDate = entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Active = false;
            entity.Habilitado = false;
            await _requisitoRepository.Update(idRequisito, entity);
            var alertas = await _alertaRepository.ListBy(s => s.IdRequisito == idRequisito);
            if (alertas.Count() > 0)
            {
                foreach (var alerta in alertas)
                {
                    alerta.RemovalDate = entity.UpdateDate = DateTime.Now;
                    alerta.UpdateUserId = currUser.Id;
                    alerta.Active = false;
                }
                await _alertaRepository.UpdateRange(alertas);
            }
        }
        private IEnumerable<RequisitoDTO> AddTranscripcionRegla(IEnumerable<Requisito> requisitos)
        {
            var result = new List<RequisitoDTO>();
            foreach (var requisito in requisitos)
            {
                var dto = _mapper.Map<RequisitoDTO>(requisito);
                var req1 = "";
                switch (requisito.IdTipoRegla)
                {
                    case 1:
                        {
                            req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                            dto.TranscripcionRegla = $"Cada { req1 }, debe tener asignado {requisito.IdTipoRecursoMaterial2Navigation.Descripcion} cada {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                            break;
                        } 
                    case 2:
                        {
                            req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                            dto.TranscripcionRegla = $"Cada { req1 }, debe tener asignado y vigente {requisito.IdTipoRecursoRenovableNavigation.Descripcion}";
                            break;
                        }
                    case 3:
                        {
                            req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                            dto.TranscripcionRegla = $"Cada { req1 }, debe tener asignado {requisito.IdTipoRecursoMaterial2Navigation.Descripcion}";
                            break;
                        }
                    case 4:
                        {
                            req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                            dto.TranscripcionRegla = $"Cada { req1 }, debe tener un ciclo de vida superior a {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                            break;
                        }
                    case 5:
                        {
                            req1 = requisito.IdTipoRecursoMaterial1Navigation != null ? requisito.IdTipoRecursoMaterial1Navigation.Descripcion : requisito.IdTipoRecurso1Navigation.Descripcion;
                            dto.TranscripcionRegla = $"Cada { req1 }, no debe estar fuera de servicio por mas de {requisito.Periodicidad} {((UTiempoEnum)requisito.IdUtiempo).GetDescription()}";
                            break;
                        }
                    default:
                        break;
                }
                result.Add(dto);
            }
            return result;

        }
    }
}
