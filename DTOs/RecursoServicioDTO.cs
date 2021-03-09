using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoServicioDTO
    {
        public int Id { get; set; }
        public int IdRecurso { get; set; }
        public int IdServicio { get; set; }
        public DateTime? FechaAsignado { get; set; }
        public DateTime? FechaDesasignado { get; set; }
        public string MotivoDesasignacion { get; set; }
        public int? IdMotivoDesasignacion { get; set; }
        public int? IdUbicacion { get; set; }
        public ServicioDTO Servicio { get; set; }
        public string Cliente { get; set; }
        public string Encargado { get; set; }


    }
}
public class RecursoServicioFilterDTO
{
    public DateTime? FechaAsignadoFrom { get; set; }
    public DateTime? FechaAsignadoTo { get; set; }
    public int? IdTipoRecurso { get; set; }

    public RecursoServicioFilterDTO(DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idTipoRecurso = null)
    {
        FechaAsignadoTo = creationDateTo;
        FechaAsignadoFrom = creationDateFrom;
        IdTipoRecurso = idTipoRecurso;
    }
}
