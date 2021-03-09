using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Requisito : BaseEntity
    {
        public Requisito()
        {
            Alerta = new HashSet<Alerta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdTipoRequisito { get; set; }
        public bool? Activo { get; set; }
        public int? Periodicidad { get; set; }
        public DateTime? FechaCumplido { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool? ValidarVigencia { get; set; }
        public int? IdServicio { get; set; }
        public int? IdTipoRecurso1 { get; set; }
        public int? IdTipoRecurso2 { get; set; }
        public string TipoRequisito { get; set; }
        public int? IdTipoRegla { get; set; }
        public int? IdTipoRecursoMaterial1 { get; set; }
        public int? IdTipoRecursoMaterial2 { get; set; }
        public int? IdTipoRecursoRenovable { get; set; }
        public int? IdUtiempo { get; set; }
        public bool Habilitado { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual TipoRecurso IdTipoRecurso1Navigation { get; set; }
        public virtual TipoRecurso IdTipoRecurso2Navigation { get; set; }
        public virtual TipoRecursoMaterial IdTipoRecursoMaterial1Navigation { get; set; }
        public virtual TipoRecursoMaterial IdTipoRecursoMaterial2Navigation { get; set; }
        public virtual TipoRecursoRenovable IdTipoRecursoRenovableNavigation { get; set; }

        public virtual TipoRegla IdTipoReglaNavigation { get; set; }
        public virtual ICollection<Alerta> Alerta { get; set; }
    }
}
