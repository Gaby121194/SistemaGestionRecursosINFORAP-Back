using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface ITipoRecursoMaterialService
    {
        Task<IEnumerable<TipoRecursoMaterialDTO>> List(UsuarioDTO userlogged, TipoRecursoMaterialFilterDTO filter = null);
        Task<TipoRecursoMaterialDTO> GetById(UsuarioDTO userLogged, int id);
        Task<TipoRecursoMaterialDTO> Create(UsuarioDTO userLogged, TipoRecursoMaterialDTO dto);
        Task<TipoRecursoMaterialDTO> Update(UsuarioDTO userLogged, int id, TipoRecursoMaterialDTO dto);
        Task<bool> Remove(UsuarioDTO loggedUser, int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);
    }
}
