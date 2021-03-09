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
    public class EstadoService : IEstadoService
    {
        private readonly IBaseRepository<Estado> _estadoRepository;
        private readonly IMapper _mapper;

        public EstadoService(IBaseRepository<Estado> estadoRepository, IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }
        public async Task<EstadoDTO> Create(EstadoDTO dto)
        {
            var entity = _mapper.Map<Estado>(dto);
            entity.CreationDate = DateTime.Now;
            entity.Active = true;
            entity = await _estadoRepository.Insert(entity);
            return _mapper.Map<EstadoDTO>(entity);
        }

        public async Task<EstadoDTO> GetById(int id)
        {
            var entity = await _estadoRepository.GetById(id);
            var dto = _mapper.Map<EstadoDTO>(entity);
            return dto;
        }

        public async Task<IEnumerable<EstadoDTO>> List()
        {
            var entities = await _estadoRepository.ListBy(e=> e.Active== true);
            var dtos = _mapper.Map<IEnumerable<EstadoDTO>>(entities);
            return dtos;
        }

        public async Task Remove(int id)
        {
            var entity = await _estadoRepository.GetById(id);
            entity.Active = false;
            entity.RemovalDate = DateTime.Now;
            await _estadoRepository.Update(id, entity);
        }

        public async Task<EstadoDTO> Update(int id, EstadoDTO dto)
        {
            var oldentity = await _estadoRepository.GetById(id);
            var entity = _mapper.Map<Estado>(dto);
            entity.CreationDate = oldentity.CreationDate;
            entity.Active = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = 1;
            entity = await _estadoRepository.Update(id, entity);
            return _mapper.Map<EstadoDTO>(entity);
        }
    }
}
