using INFORAP.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class StockRecursoMaterialDTO
    {
        public int? Id { get; set; }
        public int? IdRecursoMaterial { get; set; }
        public int? CantidadTotal { get; set; }
        public int? CantidadDisponible { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdUbicacion { get; set; }
        public string RefUbicacion { get; set; }
        public DateTime? CreationDate { get; set; }

        public Ubicacion IdUbicacionNavigation { get; set; }
    }

    public class StockRecursoMaterialFilterDTO
    {
        public StockRecursoMaterialFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
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
