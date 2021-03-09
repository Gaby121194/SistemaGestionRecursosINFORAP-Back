using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class PermisoRol : BaseEntity
    {
        public int Id { get; set; }
        public int PermisoId { get; set; }
        public int RolId { get; set; }

        public virtual Permiso Permiso { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
