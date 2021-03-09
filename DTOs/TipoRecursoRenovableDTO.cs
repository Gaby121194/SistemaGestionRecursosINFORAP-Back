using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class TipoRecursoRenovableDTO
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreationDate { get; set; }


    }

    public class TipoRecursoRenovableFilterDTO
    {
        public TipoRecursoRenovableFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            Name = name;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
           
        }

        public string Name { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
      

    }
}
