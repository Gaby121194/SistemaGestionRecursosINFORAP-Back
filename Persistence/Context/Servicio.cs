using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class Servicio : BaseEntity
    {
        public Servicio()
        {
            Adjunto = new HashSet<Adjunto>();
            Requisito = new HashSet<Requisito>();
            ServicioRecurso = new HashSet<ServicioRecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? NroContrato { get; set; }
        public string Objetivo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public int? IdRecursoHumano1 { get; set; }
        public int? IdRecursoHumano2 { get; set; }
        public int? IdMotivoBajaServicio { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual MotivoBajaServicio IdMotivoBajaServicioNavigation { get; set; }
        public virtual RecursoHumano IdRecursoHumano1Navigation { get; set; }
        public virtual RecursoHumano IdRecursoHumano2Navigation { get; set; }
        public virtual ICollection<Adjunto> Adjunto { get; set; }
        public virtual ICollection<Requisito> Requisito { get; set; }
        public virtual ICollection<ServicioRecurso> ServicioRecurso { get; set; }
    }
}
