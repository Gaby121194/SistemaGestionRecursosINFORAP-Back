using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> List(UsuarioDTO userLogged, bool isSuperUser, UsuarioFilterDTO filter = null);
        Task<UsuarioDTO> GetBy(int id);
        Task<UsuarioDTO> GetIfNotExpiredBy(int id);
        Task<UsuarioDTO> Update(UsuarioDTO loggedUser, int id, UsuarioDTO dto,bool markAsExpired = false);
        Task<UsuarioDTO> Insert(UsuarioDTO loggedUser, UsuarioDTO dto);
        Task<UsuarioDTO> GetBy(string userName);
        Task UpdatePassword(int id, string password);
        Task Remove(int id, UsuarioDTO loggedUser);

        Task<bool> Exists(string username);
    }
}
