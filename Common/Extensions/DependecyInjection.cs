using INFORAP.API.Common.Security;
using INFORAP.API.Common.Utility;
using INFORAP.API.Domain.Factories;
using INFORAP.API.Domain.IServices;
using INFORAP.API.Domain.Services;
using INFORAP.API.Domain.Strategies;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.MongoDb.Repositories;
using INFORAP.API.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Extensions
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IUbicacionService, UbicacionService>();
            services.AddScoped<ITipoRecursoMaterialService, TipoRecursoMaterialService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IRecursoHumanoService, RecursoHumanoService>();
            services.AddScoped<IRecursoMaterialService, RecursoMaterialService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IRecursoRenovableService, RecursoRenovableService>();
            services.AddSingleton<ISecurityConfiguration>(sp =>
                              sp.GetRequiredService<IOptions<SecurityConfiguration>>().Value);
            services.AddScoped<ITipoRecursoService, TipoRecursoService>();
            services.AddScoped<IRecursoService, RecursoService>();
            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPermisoService, PermisoService>();
            services.AddScoped<ITipoRecursoRenovableService, TipoRecursoRenovableService>();
            services.AddScoped<IStockRecursoMaterialService, StockRecursoMaterialService>();
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<ITipoReglaService, TipoReglaService>();
            services.AddScoped<IRequisitoService, RequisitoService>();
            services.AddScoped<IMotivoBajaServicioService, MotivoBajaServicioService>();
            services.AddScoped<IAlertaService, AlertaService>();
            services.AddScoped<IControladorService, ControladorService>();

            services.AddScoped<IMailClient, MailClient>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IRecursoAsignadoService, RecursoAsignadoService>();
            services.AddScoped<ReglaTipoUnoAlertGenerator>();
            services.AddScoped<ReglaTipoDosAlertGenerator>();
            services.AddScoped<ReglaTipoTresAlertGenerator>();
            services.AddScoped<ReglaTipoCuatroAlertGenerator>();
            services.AddScoped<ReglaTipoCincoAlertGenerator>();
 
            services.AddScoped<IAlertGenerationFactory, AlertGenerationFactory>();
            services.AddScoped(provider =>
            {
                var factory = (IAlertGenerationFactory)provider.GetService(typeof(IAlertGenerationFactory));
                return factory.Create();
            });
            services.AddScoped<IAlertGenerationStrategy, AlertGenerationStrategy>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IBackupService, BackupService>();

            services.AddSingleton<IInforapMongoConfiguration>(sp =>
                             sp.GetRequiredService<IOptions<InforapMongoConfiguration>>().Value);
            services.AddScoped<IDBBackupRepository, DBBackupRepository>();



            return services;
        }
    }
}
