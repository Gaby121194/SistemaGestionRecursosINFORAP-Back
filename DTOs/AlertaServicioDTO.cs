using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class AlertaServicioDTO
    {
        public AlertaServicioDTO()
        {
            Alertas = new HashSet<AlertaDTO>();
        }

        public ServicioDTO Servicio { get; set; }

        public ICollection<AlertaDTO> Alertas { get; set; }
    }
}
