using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Controlador : BaseEntity
    {
        public Controlador()
        {
            PermisoControladorAccion = new HashSet<PermisoControladorAccion>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }
        public bool Show { get; set; }

        public virtual ICollection<PermisoControladorAccion> PermisoControladorAccion { get; set; }
    }
}
