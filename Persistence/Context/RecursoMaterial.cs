using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class RecursoMaterial : BaseEntity
    {
        public RecursoMaterial()
        {
            FueraServicio = new HashSet<FueraServicio>();
            StockRecursoMaterial = new HashSet<StockRecursoMaterial>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? DiasFueraServicio { get; set; }
        public int IdRecurso { get; set; }
        public int? Cantidad { get; set; }
        public bool? Multiservicio { get; set; }
        public bool? Stockeable { get; set; }
        public int IdTipoRecursoMaterial { get; set; }

        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual TipoRecursoMaterial IdTipoRecursoMaterialNavigation { get; set; }
        public virtual ICollection<FueraServicio> FueraServicio { get; set; }
        public virtual ICollection<StockRecursoMaterial> StockRecursoMaterial { get; set; }
    }
}
