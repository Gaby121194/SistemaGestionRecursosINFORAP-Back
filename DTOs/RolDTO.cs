using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RolDTO : BaseDTO
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdEmpresa { get; set; }
        public int[] Permisos { get; set; }

        public DateTime creationDate { get; set; }
        public override bool? Active { get; set; }
        public EmpresaDTO Empresa { get; set; }

        public class RolFilterDTO
        {
            public RolFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
            {
                Datos = name;
                IdEmpresa = idEmpresa;
                CreationDateFrom = creationDateFrom;
                CreationDateTo = creationDateTo;
            }

            public string Datos { get; set; }
            public DateTime? CreationDateFrom { get; set; }
            public DateTime? CreationDateTo { get; set; }
            public int? IdEmpresa { get; set; }
        }

    }
}
