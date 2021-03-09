using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class RecursoRenovable : BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdRecurso { get; set; }
        public int? IdTipoRecursoRenovable { get; set; }

        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual TipoRecursoRenovable IdTipoRecursoRenovableNavigation { get; set; }
    }
}
