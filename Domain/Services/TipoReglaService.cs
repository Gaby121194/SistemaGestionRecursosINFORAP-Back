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
    public class TipoReglaService : ITipoReglaService
    {
        private readonly IBaseRepository<TipoRegla> _tipoReglaRepository;
        private readonly IMapper _mapper;

        public TipoReglaService(IBaseRepository<TipoRegla> tipoReglaRepository, IMapper mapper)
        {
            _tipoReglaRepository = tipoReglaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoReglaDTO>> List()
        {
            return _mapper.Map<IEnumerable<TipoReglaDTO>>(await _tipoReglaRepository.ListBy(s => s.Active));
        }

    }
}
