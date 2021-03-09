using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{
    public enum EstadosEnum
    {
        [Description("Disponible")]
        Disponible = 1,
        [Description("Asignado")]
        Asignado = 2,
        [Description("Fuera de Servicio")]
        Fuera_de_Servicio = 3,
        [Description("Dado de baja")]
        Dado_de_Baja = 4
    }
}
