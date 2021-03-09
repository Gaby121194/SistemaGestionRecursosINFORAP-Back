using INFORAP.API.Common.Enumerations;
using INFORAP.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Strategies
{
    public interface IAlertGenerationStrategy
    {
        Task GenerateAlerts(Requisito requisito);
    }
    public class AlertGenerationStrategy : IAlertGenerationStrategy
    {

        private readonly IAlertGenerator[] _alertGenerators;

        public AlertGenerationStrategy(IAlertGenerator[] alertGenerators)
        {
            _alertGenerators = alertGenerators;
        }
        public Task GenerateAlerts(Requisito requisito)
        {
             return _alertGenerators.FirstOrDefault(x => x.TipoRegla == (TipoReglaEnum)requisito.IdTipoRegla)?.GenerateAlerts(requisito) ?? throw new ArgumentNullException(nameof(requisito.IdTipoRegla));
        }
    }


}
