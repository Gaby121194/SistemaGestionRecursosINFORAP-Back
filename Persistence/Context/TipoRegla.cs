using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class TipoRegla : BaseEntity
    {
        public TipoRegla()
        {
            Requisito = new HashSet<Requisito>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Requisito> Requisito { get; set; }
    }
}
