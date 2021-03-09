using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoMaterialDTO
    {
        public int? Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? DiasFueraServicio { get; set; }
        public int IdRecurso { get; set; }
        public bool? Multiservicio { get; set; }
        public bool? Stockeable { get; set; }
        public int IdTipoRecursoMaterial { get; set; }
        public int? IdEstado { get; set; }
        public TipoRecursoMaterialDTO IdTipoRecursoMaterialNavigation { get; set; }
        public RecursoDTO IdRecursoNavigation { get; set; }
        public EstadoDTO IdEstadoNavigation { get; set; }

        public DateTime creationDate { get; set; }

        public int? IdUbicacion { get; set; }
        public DateTime? fechaInicioFueraServicio { get; set; }

        public bool boolAsignados { get; set; }

    }

    public class RecursosMaterialesFilterDTO
    {
        public RecursosMaterialesFilterDTO(string name = null, string idEstado = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            Name = name;
            IdEstado = idEstado;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string Name { get; set; }
        public string IdEstado { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }

    }
}
