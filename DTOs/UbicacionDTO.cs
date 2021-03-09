using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class UbicacionDTO
    {
        public int? Id { get; set; }
        public int IdProvincia { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }
        public string DescripcionProvincia { get; set; }
        public DateTime creationDate { get; set; }
        public int? IdEmpresa { get; set; }
        public EmpresaDTO Empresa { get; set; }

    }
    public class UbicacionFilterDTO
    {
        public UbicacionFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
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
