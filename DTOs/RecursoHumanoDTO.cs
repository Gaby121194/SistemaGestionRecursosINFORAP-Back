using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoHumanoDTO : BaseDTO
    {
        public int? Id { get; set; }
        public int? IdRecurso { get; set; }
        public string Cuil { get; set; }
        public string Direccion { get; set; }
        public bool? Multiservicio { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroLegajo { get; set; }
        public int IdEmpresa { get; set; }

        public string Imagen { get; set; }
    }
    public class RecursoHumanoFilterDTO
    {
        public RecursoHumanoFilterDTO(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            Nombre = name;
            IdEmpresa = idEmpresa;
            CreationDateFrom = creationDateFrom;
            CreationDateTo = creationDateTo;
        }

        public string Nombre { get; set; }
        public int? IdEmpresa { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
    }
}