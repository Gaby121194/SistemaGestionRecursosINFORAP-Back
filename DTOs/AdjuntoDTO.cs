using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class AdjuntoDTO: BaseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int? IdServicio { get; set; }

        public int? IdRecursoHumano { get; set; }
    }
}
