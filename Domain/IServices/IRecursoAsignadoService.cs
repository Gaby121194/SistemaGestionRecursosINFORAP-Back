using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRecursoAsignadoService
    {
        Task<IEnumerable<RecursoAsignadoDTO>> ListRRMM(UsuarioDTO userlogged, int idRecurso, RecursoAsignadoFilterDTO filter = null);
        Task<IEnumerable<RecursoAsignadoDTO>> ListRRRR(UsuarioDTO userlogged, int idRecurso, RecursoAsignadoFilterDTO filter = null);
        Task<RecursoAsignadoDTO> CreateRRRR(UsuarioDTO userLogged, RecursoAsignadoDTO dto);
        Task<RecursoAsignadoDTO> CreateRRMM(UsuarioDTO userLogged, RecursoAsignadoDTO dto);
        Task<RecursoAsignadoDTO> GetById(UsuarioDTO userLogged, int id);
        Task<RecursoAsignadoDTO> Update(UsuarioDTO userLogged, int id, RecursoAsignadoDTO dto);
        Task Remove(UsuarioDTO loggedUser, int id);
        Task<IEnumerable<RecursoAsignadoDTO>> ListMaterialesWhereAsignado(UsuarioDTO userlogged, int idRecurso);

        
    }
}
