using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.Context
{
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public int CreationUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? RemovalDate { get; set; }
        public bool Active { get; set; }
      
    }
}
