using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class BaseDTO
    {
        public virtual DateTime? CreationDate { get; set; }
        public virtual int? CreationUserId { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual int? UpdateUserId { get; set; }
        public virtual DateTime? RemovalDate { get; set; }
        public virtual bool? Active { get; set; }
    }
}
