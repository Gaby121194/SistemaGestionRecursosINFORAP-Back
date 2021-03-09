using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Accion
    {
        public Accion()
        {
            PermisoControladorAccion = new HashSet<PermisoControladorAccion>();
        }

        public int Id { get; set; }
        public string NombreAccion { get; set; }
        public string Display { get; set; }

        public virtual ICollection<PermisoControladorAccion> PermisoControladorAccion { get; set; }
    }
}
