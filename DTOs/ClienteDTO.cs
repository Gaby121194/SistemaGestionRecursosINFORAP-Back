using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class ClienteDTO
    {
        public int? Id { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cuil { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime creationDate { get; set; }
        public EmpresaDTO Empresa { get; set; }
    }

    public class ClienteFilterDTO
    {
        public ClienteFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            Name = name;
            IdEmpresa = idEmpresa;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string Name { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
    }
}
