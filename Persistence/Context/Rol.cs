using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Rol : BaseEntity
    {
        public Rol()
        {
            PermisoRol = new HashSet<PermisoRol>();
            InverseUsuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<PermisoRol> PermisoRol { get; set; }
        public virtual ICollection<Usuario> InverseUsuario { get; set; }
    }
}
