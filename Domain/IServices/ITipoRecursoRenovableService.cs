using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface ITipoRecursoRenovableService
    {
        Task<IEnumerable<TipoRecursoRenovableDTO>> List(UsuarioDTO userlogged, TipoRecursoRenovableFilterDTO filter = null);
        Task<TipoRecursoRenovableDTO> GetById(UsuarioDTO userLogged, int id);
        Task<TipoRecursoRenovableDTO> Create(UsuarioDTO userLogged, TipoRecursoRenovableDTO dto);
        Task<TipoRecursoRenovableDTO> Update(UsuarioDTO userLogged, int id, TipoRecursoRenovableDTO dto);
        Task<bool> Remove(UsuarioDTO loggedUser, int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);
        
    }
}
