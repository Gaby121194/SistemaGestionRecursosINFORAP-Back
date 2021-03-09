using AutoMapper;
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
    public class TipoRecursoService : ITipoRecursoService
    {
        private readonly IBaseRepository<TipoRecurso> _tipoRecursoRepository;
        private readonly IMapper _mapper;

        public TipoRecursoService(IBaseRepository<TipoRecurso> tipoRecursoRespository, IMapper mapper)
        {
            _tipoRecursoRepository = tipoRecursoRespository;
            _mapper = mapper;
        }

        public async Task<TipoRecursoDTO> Create(TipoRecursoDTO dto)
        {
            var entities = _mapper.Map<TipoRecurso>(dto);
            entities.CreationDate = DateTime.Now;
            entities.Active = true;
            entities = await _tipoRecursoRepository.Insert(entities);
            
            return _mapper.Map<TipoRecursoDTO>(entities);
        }

        public async Task<TipoRecursoDTO> GetById(int id)
        {
            var entities = await _tipoRecursoRepository.GetById(id);
            return _mapper.Map<TipoRecursoDTO>(entities);
        }

        public async Task<IEnumerable<TipoRecursoDTO>> List()
        {
            var entities = await _tipoRecursoRepository.ListBy(e => e.Active == true);
            var dtos = _mapper.Map<IEnumerable<TipoRecursoDTO>>(entities);
            return dtos;
        }
        public async Task Remove(int id)
        {
            var entity = await _tipoRecursoRepository.GetById(id);
            entity.Active = false;
            entity.RemovalDate = DateTime.Now;

            await _tipoRecursoRepository.Update(id, entity);
        }

        public async Task<TipoRecursoDTO> Update(int id, TipoRecursoDTO dto)
        {
            var oldentity = await _tipoRecursoRepository.GetById(id);
            var entity = _mapper.Map<TipoRecurso>(dto);
            entity.Active = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = 1;
            entity.CreationDate = oldentity.CreationDate;

            entity = await _tipoRecursoRepository.Update(id, entity);
            return _mapper.Map<TipoRecursoDTO>(entity);

        }
    }
}
