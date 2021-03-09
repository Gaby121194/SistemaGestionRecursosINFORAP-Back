using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cuil { get; set; }
        public int IdEmpresa { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }
    }
}
