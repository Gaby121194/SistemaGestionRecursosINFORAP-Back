using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class RecursoAsignado : BaseEntity
    {
        public int Id { get; set; }
        public int IdRecurso1 { get; set; }
        public int IdRecurso2 { get; set; }
        public DateTime? FechaAsignado { get; set; }
        public DateTime? FechaDesasignado { get; set; }
        public string MotivoDesasignacion { get; set; }
        public int? IdMotivoDesasignacion { get; set; }
        public int? IdUbicacion { get; set; }

        public virtual MotivoDesasignacion IdMotivoDesasignacionNavigation { get; set; }
        public virtual Recurso IdRecurso1Navigation { get; set; }
        public virtual Recurso IdRecurso2Navigation { get; set; }
        public virtual Ubicacion IdUbicacionNavigation { get; set; }
    }
}
