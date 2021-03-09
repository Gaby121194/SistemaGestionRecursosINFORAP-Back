using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class AlertaDTO : BaseDTO
    {
        public AlertaDTO()
        {
            Recursos = new HashSet<RecursoDTO>();
        }

        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Observacion { get; set; }
        public int? IdRequisito { get; set; }
        public int? IdFueraServicio { get; set; }
        public int? IdRecurso1 { get; set; }
        public int? IdRecurso2 { get; set; }

        public RequisitoDTO Requisito { get; set; }
        public ICollection<RecursoDTO> Recursos { get; set; }

    }
}
