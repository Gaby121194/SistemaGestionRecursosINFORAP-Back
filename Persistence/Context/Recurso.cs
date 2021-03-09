using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Recurso : BaseEntity
    {
        public Recurso()
        {
            AlertaIdRecurso1Navigation = new HashSet<Alerta>();
            AlertaIdRecurso2Navigation = new HashSet<Alerta>();
            RecursoAsignadoIdRecurso1Navigation = new HashSet<RecursoAsignado>();
            RecursoAsignadoIdRecurso2Navigation = new HashSet<RecursoAsignado>();
            RecursoHumano = new HashSet<RecursoHumano>();
            RecursoMaterial = new HashSet<RecursoMaterial>();
            RecursoRenovable = new HashSet<RecursoRenovable>();
            ServicioRecurso = new HashSet<ServicioRecurso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoRecurso { get; set; }
        public int? IdUbicacion { get; set; }
        public int? IdEstado { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual TipoRecurso IdTipoRecursoNavigation { get; set; }
        public virtual Ubicacion IdUbicacionNavigation { get; set; }
        public virtual ICollection<Alerta> AlertaIdRecurso1Navigation { get; set; }
        public virtual ICollection<Alerta> AlertaIdRecurso2Navigation { get; set; }
        public virtual ICollection<RecursoAsignado> RecursoAsignadoIdRecurso1Navigation { get; set; }
        public virtual ICollection<RecursoAsignado> RecursoAsignadoIdRecurso2Navigation { get; set; }
        public virtual ICollection<RecursoHumano> RecursoHumano { get; set; }
        public virtual ICollection<RecursoMaterial> RecursoMaterial { get; set; }
        public virtual ICollection<RecursoRenovable> RecursoRenovable { get; set; }
        public virtual ICollection<ServicioRecurso> ServicioRecurso { get; set; }
    }
}
