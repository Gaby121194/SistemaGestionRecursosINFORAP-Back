using INFORAP.API.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class UsuarioDTO : BaseDTO
    {
        [Key]
        [DefaultValue(0)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdRecursoHumano { get; set; }
        public override bool? Active { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdRol { get; set; }
        public string Password { get; set; }

        public RolDTO Rol { get; set; }
        public EmpresaDTO Empresa { get; set; }
    }

    public class UsuarioFilterDTO
    {
        public UsuarioFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            Nombre = name;
            IdEmpresa = idEmpresa;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string Nombre { get; set; }      
        public int? IdEmpresa { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
 
    }
}
