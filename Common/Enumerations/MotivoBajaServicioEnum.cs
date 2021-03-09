using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{
    public enum MotivoBajaServicioEnum
    {
        [Description("Fecha cumplida")]
         FechaCumplida = 1,
        [Description("Decisión del cliente")]
        DecisionCliente,
        [Description("Decisión propia")]
        DecisionPropia,
    }
}
