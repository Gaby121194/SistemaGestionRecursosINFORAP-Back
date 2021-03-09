using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static INFORAP.API.DTOs.RolDTO;

namespace INFORAP.API.Domain.IServices
{
    public interface IRolService
    {
        Task<IEnumerable<RolDTO>> List(UsuarioDTO userLogged, bool isSuperUser, RolFilterDTO filter = null);
        Task<IEnumerable<RolDTO>> ListByEmpresaId(int id);
        Task<RolDTO> GetById(int id);
        Task<RolDTO> Create(RolDTO dto, UsuarioDTO userLogged);
        Task<RolDTO> Update(int id, RolDTO rol, UsuarioDTO userLogged);
        Task Remove(int id);
        Task<bool> IsSuperUser(int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id= null);
    }
}
