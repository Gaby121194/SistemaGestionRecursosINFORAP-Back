using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Alerta : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdEstado { get; set; }       
        public DateTime? FechaFin { get; set; }
        public string Observacion { get; set; }
        public int? IdRequisito { get; set; }
        public int? IdFueraServicio { get; set; }
        public int? IdRecurso1 { get; set; }
        public int? IdRecurso2 { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual FueraServicio IdFueraServicioNavigation { get; set; }
        public virtual Recurso IdRecurso1Navigation { get; set; }
        public virtual Recurso IdRecurso2Navigation { get; set; }
        public virtual Requisito IdRequisitoNavigation { get; set; }
    }
}
