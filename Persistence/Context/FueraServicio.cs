using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class FueraServicio : BaseEntity
    {
        public FueraServicio()
        {
            Alerta = new HashSet<Alerta>();
        }

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string MotivoSalida { get; set; }
        public int? IdRecursoMaterial { get; set; }
        public int? IdMotivoFueraServicio { get; set; }

        public virtual MotivoFueraServicio IdMotivoFueraServicioNavigation { get; set; }
        public virtual RecursoMaterial IdRecursoMaterialNavigation { get; set; }
        public virtual ICollection<Alerta> Alerta { get; set; }
    }
}
