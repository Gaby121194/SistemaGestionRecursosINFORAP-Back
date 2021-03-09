using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> List(UsuarioDTO userLogged, ClienteFilterDTO filter = null);
        Task<ClienteDTO> GetById(UsuarioDTO userLogged, int id);
        Task<ClienteDTO> Create(UsuarioDTO userLogged, ClienteDTO ubicacion);
        Task<ClienteDTO> Update(UsuarioDTO userLogged, int id, ClienteDTO ubicacion);
        Task<bool> Remove(UsuarioDTO loggedUser, int id);
        Task<bool> Exists(UsuarioDTO LoggedUser, string name, int? id = null);
    }
}
