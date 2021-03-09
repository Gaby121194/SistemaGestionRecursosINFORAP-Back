using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Estado : BaseEntity
    {
        private int? idEstado;
        private object descripcion;

        public Estado()
        {
            Alerta = new HashSet<Alerta>();
            Recurso = new HashSet<Recurso>();
        }

        public Estado(int? idEstado, object descripcion)
        {
            this.idEstado = idEstado;
            this.descripcion = descripcion;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Alerta> Alerta { get; set; }
        public virtual ICollection<Recurso> Recurso { get; set; }
    }
}
