using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Permiso : BaseEntity
    { 
        public Permiso()
        {
            PermisoControladorAccion = new HashSet<PermisoControladorAccion>();
            PermisoRol = new HashSet<PermisoRol>();
        }

        public int Id { get; set; }
        public string NombrePermiso { get; set; }
        public string DescripcionPermiso { get; set; }
        public bool IsSuperUser { get; set; }

        public virtual ICollection<PermisoControladorAccion> PermisoControladorAccion { get; set; }
        public virtual ICollection<PermisoRol> PermisoRol { get; set; }
    }
}
