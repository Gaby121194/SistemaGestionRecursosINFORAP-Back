using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class RecursoHumano : BaseEntity
    {
        public RecursoHumano()
        {
            Adjunto = new HashSet<Adjunto>();
            ServicioIdRecursoHumano1Navigation = new HashSet<Servicio>();
            ServicioIdRecursoHumano2Navigation = new HashSet<Servicio>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public int IdRecurso { get; set; }
        public string Cuil { get; set; }
        public string Direccion { get; set; }
        public bool? Multiservicio { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroLegajo { get; set; }
        public int IdEmpresa { get; set; }
        public string Imagen { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Recurso IdRecursoNavigation { get; set; }
        public virtual ICollection<Adjunto> Adjunto { get; set; }
        public virtual ICollection<Servicio> ServicioIdRecursoHumano1Navigation { get; set; }
        public virtual ICollection<Servicio> ServicioIdRecursoHumano2Navigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
