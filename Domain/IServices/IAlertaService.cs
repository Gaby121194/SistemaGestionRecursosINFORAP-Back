using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
   public interface IAlertaService
    {
        Task<int> CountAlertsFor(UsuarioDTO currUser);
        Task<IEnumerable<AlertaServicioDTO>> ListAlertsFor(UsuarioDTO currUser);
    }
}
