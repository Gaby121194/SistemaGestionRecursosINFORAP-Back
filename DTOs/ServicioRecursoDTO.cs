using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class ServicioRecursoDTO
    {
        public int Id { get; set; }
        public int IdRecurso { get; set; }
        public int IdServicio { get; set; }
        public DateTime? FechaAsignado { get; set; }
        public DateTime? FechaDesasignado { get; set; }
        public string MotivoDesasignacion { get; set; }
        public int? IdMotivoDesasignacion { get; set; }
        public int? IdUbicacion { get; set; }

        public  RecursoDTO Recurso { get; set; }
        public  TipoRecursoDTO TipoRecurso { get; set; }

    }

    public class ServicioRecursoFilterDTO
    {
        public DateTime? FechaAsignadoFrom { get; set; }
        public DateTime? FechaAsignadoTo { get; set; }
        public int? IdTipoRecurso { get; set; }

        public ServicioRecursoFilterDTO(DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idTipoRecurso = null)
        {
            FechaAsignadoTo = creationDateTo;
            FechaAsignadoFrom = creationDateFrom;
            IdTipoRecurso = idTipoRecurso;
        }
    }
}
