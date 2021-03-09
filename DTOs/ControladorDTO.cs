using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class ControladorDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }
        public bool Show { get; set; }
    }

    public class ControladorFilterDTO 
    {
        public ControladorFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
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
