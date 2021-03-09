using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class PermisoControladorAccion
    {
        public int Id { get; set; }
        public int PermisoId { get; set; }
        public int ControladorId { get; set; }
        public int? AccionId { get; set; }

        public virtual Accion Accion { get; set; }
        public virtual Controlador Controlador { get; set; }
        public virtual Permiso Permiso { get; set; }
    }
}
