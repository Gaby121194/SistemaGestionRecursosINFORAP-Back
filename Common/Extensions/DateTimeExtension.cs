using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using System;
namespace INFORAP.API.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime AddDiff(this DateTime date, UTiempoEnum uTiempo, int diff)
        {
            switch (uTiempo)
            {
                case UTiempoEnum.Anio:
                    return date.AddYears(diff);
                case UTiempoEnum.Mes:
                    return date.AddMonths(diff);
                case UTiempoEnum.Dia:
                    return date.AddDays(diff);
                default:
                    throw new BadRequestException("La unidad de medida no se corresponde con ningún valor acordado");
            }
        }
    }
}
