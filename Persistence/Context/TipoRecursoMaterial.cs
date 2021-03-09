using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    public partial class TipoRecursoMaterial : BaseEntity
    {
        public TipoRecursoMaterial()
        {
            RecursoMaterial = new HashSet<RecursoMaterial>();
            Requisito_1 = new HashSet<Requisito>();
            Requisito_2 = new HashSet<Requisito>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public int? IdEmpresa { get; set; }

        public virtual ICollection<RecursoMaterial> RecursoMaterial { get; set; }
        public virtual ICollection<Requisito> Requisito_1 { get; set; }
        public virtual ICollection<Requisito> Requisito_2 { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa{ get; set; }
    }
}
