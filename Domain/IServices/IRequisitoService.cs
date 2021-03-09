using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRequisitoService
    {
        Task<IEnumerable<RequisitoDTO>> ListBy(int idServicio, int idEmpresa);
        Task<RequisitoDTO> Insert(int idServicio, RequisitoDTO dto, UsuarioDTO currUser);
        Task Remove(int idRequisito, UsuarioDTO currUser);
    }
}
