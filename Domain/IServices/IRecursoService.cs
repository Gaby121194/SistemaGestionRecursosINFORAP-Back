using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRecursoService
    {
        Task<IEnumerable<RecursoDTO>> List();
        Task<RecursoDTO> GetById(int id);
        Task<RecursoDTO> Create(RecursoDTO dto);
        Task<RecursoDTO> Update(int id, RecursoDTO dto);
        Task Remove(int id);
        Task<IEnumerable<ServicioRecursoDTO>> ListFromService(int IdServicio, ServicioRecursoFilterDTO filter, UsuarioDTO currUser);
        Task InsertServicioRecurso(int idServicio, ServicioRecursoDTO dto, UsuarioDTO currUser);
        Task DeleteServicioRecurso(int idServicioRecurso, UsuarioDTO currUser);
        Task<IEnumerable<RecursoServicioDTO>> ListFromResource(int IdRecurso, RecursoServicioFilterDTO filter, UsuarioDTO currUser);
    }
}
