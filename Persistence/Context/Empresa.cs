using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Empresa : BaseEntity
    {
        public Empresa()
        {
            Recurso = new HashSet<Recurso>();
            RecursoHumano = new HashSet<RecursoHumano>();
            Rol = new HashSet<Rol>();
            Servicio = new HashSet<Servicio>();
            StockRecursoMaterial = new HashSet<StockRecursoMaterial>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Logo { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string CorreoContacto { get; set; }
        public string UsuarioContacto { get; set; }
       

        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<RecursoHumano> RecursoHumano { get; set; }
        public virtual ICollection<Rol> Rol { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
        public virtual ICollection<StockRecursoMaterial> StockRecursoMaterial { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
