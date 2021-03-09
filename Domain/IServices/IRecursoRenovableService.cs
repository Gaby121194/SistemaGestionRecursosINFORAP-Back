using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRecursoRenovableService
    {
        Task<IEnumerable<RecursoRenovableDTO>> List(UsuarioDTO userlogged, RecursosRenovablesFilterDTO filter = null);
        Task<RecursoRenovableDTO> Create(RecursoRenovableDTO dto, UsuarioDTO usuario);
        Task<RecursoRenovableDTO> GetById(UsuarioDTO userLogged, int id);       
        Task<RecursoRenovableDTO> Update( UsuarioDTO user, int id,  RecursoRenovableDTO dto);
        Task Remove(UsuarioDTO userLogged, int id);

        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);

        Task<IEnumerable<RecursoRenovableDTO>> ListRRRRFromRecurso(int idRecurso1, UsuarioDTO currUser);

    }
}
