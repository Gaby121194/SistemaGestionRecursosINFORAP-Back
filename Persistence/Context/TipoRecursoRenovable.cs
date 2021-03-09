using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    public partial class TipoRecursoRenovable : BaseEntity
    {
        public TipoRecursoRenovable()
        {
            RecursoRenovable = new HashSet<RecursoRenovable>();
            Requisito = new HashSet<Requisito>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual ICollection<RecursoRenovable> RecursoRenovable { get; set; }
        public virtual ICollection<Requisito> Requisito{ get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

    }
}
