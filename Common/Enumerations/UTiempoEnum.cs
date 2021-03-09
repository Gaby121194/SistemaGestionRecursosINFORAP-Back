using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{
    public enum UTiempoEnum
    {
        [Description("Día/s")]
        Dia = 1,
        [Description("Mes/es")]
        Mes = 2,
        [Description("Año/s")]
        Anio = 3
    }
}
