using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdRecursoHumano { get; set; }     
        public int? IdRol { get; set; }
        public bool? ExpiredSession { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual RecursoHumano RecursoHumano { get; set; }
        [ForeignKey("IdRol")]
        public virtual Rol Rol { get; set; }
    }
}
