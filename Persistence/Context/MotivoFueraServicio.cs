using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class MotivoFueraServicio : BaseEntity
    {
        public MotivoFueraServicio()
        {
            FueraServicio = new HashSet<FueraServicio>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<FueraServicio> FueraServicio { get; set; }
    }
}
