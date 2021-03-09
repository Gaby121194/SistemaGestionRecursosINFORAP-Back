using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class MotivoDesasignacion : BaseEntity
    {
        public MotivoDesasignacion()
        {
            RecursoAsignado = new HashSet<RecursoAsignado>();
            ServicioRecurso = new HashSet<ServicioRecurso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RecursoAsignado> RecursoAsignado { get; set; }
        public virtual ICollection<ServicioRecurso> ServicioRecurso { get; set; }
    }
}
