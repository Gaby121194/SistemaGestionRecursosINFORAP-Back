using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RequisitoDTO : BaseDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int IdTipoRequisito { get; set; }
         public int? Periodicidad { get; set; }
        public DateTime? FechaCumplido { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool? ValidarVigencia { get; set; }
        public int IdServicio { get; set; }
        public int? IdTipoRecurso1 { get; set; }
        public int? IdTipoRecurso2 { get; set; }
        public string TipoRequisito { get; set; }
        public int IdTipoRegla { get; set; }
        public int? IdTipoRecursoMaterial1 { get; set; }
        public int? IdTipoRecursoMaterial2 { get; set; }
        public int? IdTipoRecursoRenovable { get; set; }
        public int? IdUtiempo { get; set; }

        public string  TranscripcionRegla { get; set; }


    }
}
