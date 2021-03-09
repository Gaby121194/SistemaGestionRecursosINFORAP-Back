using INFORAP.API.Common.Utility;
using INFORAP.API.Domain.IServices;
using INFORAP.API.Domain.Services;
using INFORAP.API.Domain.Strategies;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.MongoDb.Repositories;
using INFORAP.API.Common.Extensions;
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
    public class BackupBackgroudService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        public BackupBackgroudService(IServiceScopeFactory serviceScopeFactory)
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
                while (AlertBackgroudService.InProgress || ServicesBackgroudService.InProgress)
                {
                    Thread.Sleep(5000);
                }
              GenerateBackup().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {

                return;
            }
        }

        private async Task GenerateBackup()
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IBackupService _backupService = scope.ServiceProvider.GetRequiredService<IBackupService>();
                    IDatabaseService _dataBaseService = scope.ServiceProvider.GetRequiredService<IDatabaseService>();
                    var script = new StringBuilder();
                    var databaseName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_NAME");
                    var backupDirectory = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_BACKUP_DIRECTORY");
                    script.Append(await _dataBaseService.ScriptDrops());
                    script.Append(await _dataBaseService.ScriptSchemaAndData());
                    var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_bck_" + databaseName;
                 ///  await File.WriteAllTextAsync(backupDirectory + fileName, script.ToString());
                  
                    //var bck = new Persistence.MongoDb.Entities.DBBackup();
                    //bck.Active = true;
                    //bck.UpdateDate = bck.CreationDate = DateTime.Now;
                    //bck.UpdateUserId = bck.CreationUserId = 0;
                    //bck.Name = fileName;
                   
                    //bck.Backup = script.ToString().Base64Encode();
                    await _backupService.Insert(script.ToString(),fileName);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
