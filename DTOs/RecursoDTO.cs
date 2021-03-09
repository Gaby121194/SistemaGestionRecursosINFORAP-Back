using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoDTO : BaseDTO
    {

        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoRecurso { get; set; }
        public int? IdUbicacion { get; set; }
        public int? IdEstado { get; set; }
        public EstadoDTO IdEstadoNavigation { get; set; }
        public UbicacionDTO IdUbicacionNavigation { get; set; }
    }
}
