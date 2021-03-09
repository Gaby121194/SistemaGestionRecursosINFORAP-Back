using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
  public  interface IControladorService
    {
        Task<IEnumerable<ControladorDTO>> List(ControladorFilterDTO filter, bool onlyActive = false);
        Task<ControladorDTO> GetBy(int id);
        Task<ControladorDTO> Insert(ControladorDTO dto, UsuarioDTO currUser);
        Task<ControladorDTO> Update(ControladorDTO dto, int id, UsuarioDTO currUser);
        Task<ControladorDTO> Disable(int id, UsuarioDTO currUser);
        Task<ControladorDTO> Enable(int id, UsuarioDTO currUser);
        Task<bool> ExistDisplay(string display, int? id = null);
        Task<bool> ExistUrl(string url, int? id = null);
    }
}
