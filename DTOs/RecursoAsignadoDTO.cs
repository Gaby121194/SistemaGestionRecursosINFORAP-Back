using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoAsignadoDTO : BaseDTO
    {
        public int Id { get; set; }
        public int IdRecurso1 { get; set; }
        public int IdRecurso2 { get; set; }
        public DateTime? FechaAsignado { get; set; }
        public DateTime? FechaDesasignado { get; set; }
        public string MotivoDesasignacion { get; set; }
        public int? IdMotivoDesasignacion { get; set; }
        public int? IdUbicacion { get; set; }

        public string NombreRecurso2 { get; set; }
        public string ReferenciaUbicacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public RecursoMaterialDTO recursoMaterial { get; set; }
        public RecursoRenovableDTO recursoRenovable { get; set; }
    }


    public class RecursoAsignadoFilterDTO
    {
        public RecursoAsignadoFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
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
