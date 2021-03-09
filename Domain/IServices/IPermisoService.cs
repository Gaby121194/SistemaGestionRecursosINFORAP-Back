using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IPermisoService
    {
        Task<IEnumerable<PermisoDTO>> List();
        Task<IEnumerable<PermisoDTO>> List(PermisoFilterDTO filter, bool all = false, bool onlyActive = false);
        Task<PermisoDTO> GetBy(int id);
        Task<bool> IsSuperUser(int rolId);
        Task<PermisoDTO> Insert(PermisoDTO dto, UsuarioDTO currUser);
        Task<PermisoDTO> Update(PermisoDTO dto, int id, UsuarioDTO currUser);
        Task<PermisoDTO> Disable(int id, UsuarioDTO currUser);
        Task<PermisoDTO> Enable(int id, UsuarioDTO currUser);
        Task<bool> Exist(string nombrePermiso, int? id = null);
    }
}
