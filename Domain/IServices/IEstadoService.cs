using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IEstadoService
    {
        Task<IEnumerable<EstadoDTO>> List();
        Task<EstadoDTO> GetById(int id);
        Task<EstadoDTO> Create(EstadoDTO recursoHumano);
        Task<EstadoDTO> Update(int id, EstadoDTO recursoHumano);
        Task Remove(int id);
    }
}
