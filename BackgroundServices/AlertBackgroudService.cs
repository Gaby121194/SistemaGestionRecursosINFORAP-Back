using INFORAP.API.Domain.Strategies;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace INFORAP.API.BackgroundServices
{
    public class AlertBackgroudService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public static bool InProgress = false;
        private Timer _timer;
        public AlertBackgroudService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(Do, null, TimeSpan.Zero,
                     TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }
        private void Do(object state)
        {
            try
            {
                GenerateAlerts().GetAwaiter().GetResult();

            }
            catch (Exception)
            {

                return;
            }
        }

        private async Task GenerateAlerts()
        {
            InProgress = true;
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IBaseRepository<Requisito> _requisitoRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<Requisito>>();
                    var requisitos = await _requisitoRepository.ListBy(s => s.Active == true
                     && s.IdServicioNavigation.Active && s.IdServicioNavigation.IdEmpresaNavigation.Active,
                     s => s.IdServicioNavigation, s => s.IdServicioNavigation.IdEmpresaNavigation);
                    IAlertGenerationStrategy _alertGenerationStrategy = scope.ServiceProvider.GetRequiredService<IAlertGenerationStrategy>();
                    foreach (var requisito in requisitos)
                    {
                        await _alertGenerationStrategy.GenerateAlerts(requisito);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                InProgress = false;
            }
         
        }


    }
}
