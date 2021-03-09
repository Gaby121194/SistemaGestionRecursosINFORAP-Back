using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class BackupDTO : BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
 

    }
    public class BackupFilterDTO
    {
        public BackupFilterDTO(DateTime? creationDateFrom =null, DateTime? creationDateTo =null)
        {
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
    }
}
