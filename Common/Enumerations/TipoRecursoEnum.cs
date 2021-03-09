using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{
    public enum TipoRecursoEnum
    {
        [Description("Recurso Humano")]
        Recurso_Humano = 1,
        [Description("Recurso Material")]
        Recurso_Material = 2,
        [Description("Recurso Renovable")]
        Recurso_Renovable = 3
    }
}
