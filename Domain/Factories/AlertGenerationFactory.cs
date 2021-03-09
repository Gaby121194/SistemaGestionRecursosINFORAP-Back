using INFORAP.API.Domain.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Factories
{
    public interface IAlertGenerationFactory
    {
        IAlertGenerator[] Create();
    }
    public class AlertGenerationFactory : IAlertGenerationFactory
    {
        private readonly ReglaTipoUnoAlertGenerator _reglaTipoUnoAlertGenerator;
        private readonly ReglaTipoDosAlertGenerator _reglaTipoDosAlertGenerator;
        private readonly ReglaTipoTresAlertGenerator _reglaTipoTresAlertGenerator;
        private readonly ReglaTipoCuatroAlertGenerator _reglaTipoCuatroAlertGenerator;
        private readonly ReglaTipoCincoAlertGenerator _reglaTipoCincoAlertGenerator;

        public AlertGenerationFactory(ReglaTipoUnoAlertGenerator reglaTipoUnoAlertGenerator, ReglaTipoDosAlertGenerator reglaTipoDosAlertGenerator, ReglaTipoTresAlertGenerator reglaTipoTresAlertGenerator, ReglaTipoCuatroAlertGenerator reglaTipoCuatroAlertGenerator, ReglaTipoCincoAlertGenerator reglaTipoCincoAlertGenerator)
        {
            _reglaTipoUnoAlertGenerator = reglaTipoUnoAlertGenerator;
            _reglaTipoDosAlertGenerator = reglaTipoDosAlertGenerator;
            _reglaTipoTresAlertGenerator = reglaTipoTresAlertGenerator;
            _reglaTipoCuatroAlertGenerator = reglaTipoCuatroAlertGenerator;
            _reglaTipoCincoAlertGenerator = reglaTipoCincoAlertGenerator;
        }

        public IAlertGenerator[] Create() => new IAlertGenerator[] {
            _reglaTipoUnoAlertGenerator, 
            _reglaTipoDosAlertGenerator,
            _reglaTipoTresAlertGenerator,
            _reglaTipoCuatroAlertGenerator,
            _reglaTipoCincoAlertGenerator
        };
    }
}
