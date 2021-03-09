using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{
    public enum TipoReglaEnum
    {
        [Description("Un recurso tenga asignado otro recurso con periodo de asignación")]
        TipoUno = 1,
        [Description("Un recurso tenga asignado otro con fecha de vencimiento vigente")]
        TipoDos,
        [Description("Un recurso tenga asignado otro sin fecha de vencimiento ni periodicidad")]
        TipoTres,
        [Description("Un recurso tenga un ciclo de vida no menor a X tiempo")]
        TipoCuatro,
        [Description("Un recurso no debe estar fuera de servicio por X  tiempo")]
        TipoCinco

    }
}
