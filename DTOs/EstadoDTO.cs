using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class EstadoDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

    }
}
