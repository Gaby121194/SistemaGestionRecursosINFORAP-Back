using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class ServicioRecurso : BaseEntity
    {
        public int Id { get; set; }
        public int IdRecurso { get; set; }
        public int IdServicio { get; set; }
        public DateTime? FechaAsignado { get; set; }
        public DateTime? FechaDesasignado { get; set; }
        public string MotivoDesasignacion { get; set; }
        public int? IdMotivoDesasignacion { get; set; }
        public int? IdUbicacion { get; set; }

        public virtual MotivoDesasignacion IdMotivoDesasignacionNavigation { get; set; }
        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual Ubicacion IdUbicacionNavigation { get; set; }
    }
}
