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
    public class MotivoBajaServicioService :IMotivoBajaServicioService
    {
        private readonly IBaseRepository<MotivoBajaServicio> _motivoBajaServicioRepository;
        private readonly IMapper _mapper;

        public MotivoBajaServicioService(IBaseRepository<MotivoBajaServicio> motivoBajaServicioRepository, IMapper mapper)
        {
            _motivoBajaServicioRepository = motivoBajaServicioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MotivoBajaServicioDTO>> List()
        {
            return _mapper.Map<IEnumerable<MotivoBajaServicioDTO>>(await _motivoBajaServicioRepository.ListBy(s => s.Active == true));
        }
    }
}
