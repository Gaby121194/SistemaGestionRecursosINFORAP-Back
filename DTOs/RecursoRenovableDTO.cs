using INFORAP.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class RecursoRenovableDTO
    {
        public int? Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime creationDate { get; set; }
        public int? IdRecurso { get; set; }
        public string Descripcion { get; set; }
        public int? IdTipoRecursoRenovable { get; set; }

        public int? IdTipoRecurso { get; set; }

        public int? IdUbicacion { get; set; }
        

        public int? IdEstado { get; set; }

        public bool Active { get; set; }

       

        public TipoRecursoRenovableDTO IdTipoRecursoRenovableNavigation { get; set; }
        public RecursoDTO IdRecursoNavigation { get; set; }
        public EstadoDTO IdEstadoNavigation { get; set; }

    }

    public class RecursosRenovablesFilterDTO
        {
            public RecursosRenovablesFilterDTO(string name = null,string idEstado = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
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
        

