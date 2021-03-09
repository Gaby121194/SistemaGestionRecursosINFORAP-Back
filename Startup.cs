using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using INFORAP.API.BackgroundServices;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Mapping;
using INFORAP.API.Common.Security;
using INFORAP.API.Common.Utility;
using INFORAP.API.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace INFORAP.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;

            var builder = new ConfigurationBuilder()
              .AddEnvironmentVariables()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();

        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING").IsNullOrEmpty())
            {
                services.AddDbContext<InfoRapContext>(options =>
                {
                    options.UseSqlServer(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING"));
                });
            }
            else
            {
                services.AddDbContext<InfoRapContext>(options =>
                {
                    options.UseSqlServer(LaunchSettingstUtility.GetEnvironmentVariableFromJSON("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING"));
                });
            }
            services.AddDbContext<InfoRapContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EFConnectionString"));
            });
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(EntityToDto));
            services.AddAutoMapper(typeof(DtoToEntity));
            services.Configure<SecurityConfiguration>(opt =>
           {
               opt.Secret = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_JWT_SECRET");
               opt.EmailFrom = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_EMAIL_FROM");
               opt.PswFrom = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_EMAIL_SECRET_FROM");
           });

            services.Configure<InforapMongoConfiguration>( opt=>
            {
                 opt.ConnectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_MONGODB_CONNECTION_STRING");
                opt.DatabaseName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_MONGODB_DATABASENAME");
            }
         );
            services.AddDI();
            services.AddHostedService<AlertBackgroudService>();
            services.AddHostedService<ServicesBackgroudService>();
            services.AddHostedService<BackupBackgroudService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  IHostApplicationLifetime appLifetime)
        {

            app.Migrate();
       
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<JwtMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            //  app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
