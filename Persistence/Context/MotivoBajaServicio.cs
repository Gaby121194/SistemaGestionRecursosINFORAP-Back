using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class MotivoBajaServicio : BaseEntity
    {
        public MotivoBajaServicio()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
