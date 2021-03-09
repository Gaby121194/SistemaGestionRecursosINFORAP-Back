using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class EmpresaDTO
    {
        public int? Id { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Logo { get; set; }
        [Required]
        public string Cuit { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string CorreoContacto { get; set; }
        public string UsuarioContacto { get; set; }
        public bool? Active { get; set; }
        public DateTime creationDate { get; set; }
        public string NombreManager { get; set; }
        public string ApellidoManager { get; set; }
        public string EmailManager { get; set; }
    }
    public class EmpresaFilterDTO
    {
        public EmpresaFilterDTO(string name = null, string active = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            RazonSocial = name;
            IdEmpresa = idEmpresa;
            Active = active;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string RazonSocial { get; set; }
        public string Active { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }

    }

}
