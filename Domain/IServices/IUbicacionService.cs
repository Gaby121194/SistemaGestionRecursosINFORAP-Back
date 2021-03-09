using INFORAP.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IUbicacionService
    {
        
        Task<IEnumerable<UbicacionDTO>> List(UsuarioDTO userlogged, UbicacionFilterDTO filter = null);
        Task<IEnumerable<UbicacionDTO>> ListByRecursoMaterial(UsuarioDTO userLogged, int id);
        Task<UbicacionDTO> GetById(UsuarioDTO userLogged, int id);
        Task<UbicacionDTO> Create(UsuarioDTO userLogged, UbicacionDTO ubicacion);
        Task<UbicacionDTO> Update(UsuarioDTO userLogged, int id, UbicacionDTO ubicacion);
        Task<bool> Remove(UsuarioDTO loggedUser, int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);
    }
}
