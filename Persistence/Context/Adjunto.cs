using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Adjunto : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int? IdServicio { get; set; }
 
        public int? IdRecursoHumano { get; set; }

        public virtual RecursoHumano IdRecursoHumanoNavigation { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }

       


    }
}
