using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFORAP.API.Persistence.Context
{
    [Table("Backup")]
    public partial class Backup : BaseEntity
    {
        public Backup()
        {
         
        }
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Key { get; set; }
       
    }
}
