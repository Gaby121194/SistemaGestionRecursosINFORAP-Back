using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class PermisoDTO : BaseDTO
    {
        public int? Id { get; set; }
        public string NombrePermiso { get; set; }
        public string DescripcionPermiso { get; set; }
        public int[] ControllersIds { get; set; }
    }

    public class PermisoFilterDTO
    {
        public PermisoFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            Nombre = name;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string Nombre { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
    }
}
