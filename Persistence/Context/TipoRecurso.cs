using System;
using System.Collections.Generic;

namespace INFORAP.API.Persistence.Context
{
    public partial class TipoRecurso : BaseEntity
    {
        private int? idTipoRecurso;
        private string tipoRecurso;

        public TipoRecurso()
        {
            Recurso = new HashSet<Recurso>();
            RequisitoIdTipoRecurso1Navigation = new HashSet<Requisito>();
            RequisitoIdTipoRecurso2Navigation = new HashSet<Requisito>();
        }

        public TipoRecurso(int? idTipoRecurso, string tipoRecurso)
        {
            this.idTipoRecurso = idTipoRecurso;
            this.tipoRecurso = tipoRecurso;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Recurso> Recurso { get; set; }
        public virtual ICollection<Requisito> RequisitoIdTipoRecurso1Navigation { get; set; }
        public virtual ICollection<Requisito> RequisitoIdTipoRecurso2Navigation { get; set; }
    }
}
