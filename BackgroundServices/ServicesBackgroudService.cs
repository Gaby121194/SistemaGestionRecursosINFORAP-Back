using INFORAP.API.Domain.IServices;
using INFORAP.API.Domain.Strategies;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INFORAP.API.BackgroundServices
{
    public class ServicesBackgroudService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        public static bool InProgress = false;

        public ServicesBackgroudService(IServiceScopeFactory serviceScopeFactory)
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
                RemoveEndingServices().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {

                return;
            }
        }

        private async Task RemoveEndingServices()
        {
            InProgress = true;
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IBaseRepository<Servicio> _servicioRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<Servicio>>();
                    var servicios = await _servicioRepository.ListBy(s => s.Active == true
                     && s.FechaFin <= DateTime.Now);
                    IServicioService _servicioService = scope.ServiceProvider.GetRequiredService<IServicioService>();
                    foreach (var servicio in servicios)
                    {
                        await _servicioService.RemoveAsEnding(servicio.Id);
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
