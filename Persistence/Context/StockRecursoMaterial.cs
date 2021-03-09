using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class StockRecursoMaterial : BaseEntity
    {
        public int Id { get; set; }
        public int IdRecursoMaterial { get; set; }
        public int CantidadTotal { get; set; }
        public int? CantidadDisponible { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdUbicacion { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual RecursoMaterial IdRecursoMaterialNavigation { get; set; }
        public virtual Ubicacion IdUbicacionNavigation { get; set; }
    }
}
