using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    [Table("Ubicacion")]
    public partial class Ubicacion : BaseEntity
    {
        public Ubicacion()
        {
            Recurso = new HashSet<Recurso>();
            RecursoAsignado = new HashSet<RecursoAsignado>();
            ServicioRecurso = new HashSet<ServicioRecurso>();
            StockRecursoMaterial = new HashSet<StockRecursoMaterial>();
        }

        [Key]
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public int IdEmpresa { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }

        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<RecursoAsignado> RecursoAsignado { get; set; }
        public virtual ICollection<ServicioRecurso> ServicioRecurso { get; set; }
        public virtual ICollection<StockRecursoMaterial> StockRecursoMaterial { get; set; }
    }
}
