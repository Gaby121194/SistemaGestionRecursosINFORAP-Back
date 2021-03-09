using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface ITipoRecursoService
    {
        Task<IEnumerable<TipoRecursoDTO>> List();
        Task<TipoRecursoDTO> GetById(int id);
        Task<TipoRecursoDTO> Create(TipoRecursoDTO dto);
        Task<TipoRecursoDTO> Update(int id, TipoRecursoDTO dto);
        Task Remove(int id);
    }
}
