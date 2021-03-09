using INFORAP.API.Common.Exceptions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class DatabaseService : IDatabaseService
    {
        public static bool InProgress =false;

        public async Task Restore(string schemaScript)
        {
            InProgress = true;
            try
            {
                //var path = Path.Combine(backup.Path, backup.FileName);
                //if (!File.Exists(path)) throw new NotFoundException();
                //var schemaScript = File.ReadAllText(path);
                using (var dbContext = new InfoRapContext())
                {
                    //await dbContext.Database.EnsureDeletedAsync();
                    //dbContext.SaveChanges();
                    var database = dbContext.Database;
                    //await database.EnsureCreatedAsync(); // Works!
                    //dbContext.SaveChanges();
#pragma warning disable CS0618 // Type or member is obsolete
                    _ = await database.ExecuteSqlCommandAsync(schemaScript);
#pragma warning restore CS0618 // Type or member is obsolete
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


        public async Task<string> ScriptSchemaAndData()
        {
            try
            {
                var script = new StringBuilder();
                var databaseName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_NAME");
                var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING");
                var backupDirectory = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_BACKUP_DIRECTORY");
                Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
                Database database = server.Databases[databaseName];
                ScriptingOptions options = new ScriptingOptions
                {
                    ScriptData = true,
                    ScriptSchema = true,
                    ScriptDrops = false,
                    Indexes = true,
                    IncludeHeaders = true,
                };
                //  var ignoringTables = new string[] { "__EFMigrationsHistory","Controlador", "Accion" , "Permiso", "PermisoControladorAccion", "Provincia"
                //     ,"TipoRecurso","MotivoBajaServicio","TipoRegla","Estado" };
                foreach (Table table in database.Tables)
                {
                    //if (ignoringTables.Contains(table.Name)) continue;
                    foreach (var statement in table.EnumScript(options))
                    {
                        script.Append(statement);
                        script.Append(Environment.NewLine);
                    }
                }
                return script.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<string> ScriptDrops()
        {
            try
            {
                var script = new StringBuilder();
                var databaseName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_NAME");
                var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING");
                var backupDirectory = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_BACKUP_DIRECTORY");
                Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
                Database database = server.Databases[databaseName];
                ScriptingOptions options = new ScriptingOptions
                {
                    ScriptData = true,
                    ScriptSchema = true,
                    ScriptDrops = true,
                    Indexes = true,
                    IncludeHeaders = true,
                };

                foreach (Table table in database.Tables)
                {
                    foreach (var statement in table.EnumScript(options))
                    {
                        script.Append(statement);
                        script.Append(Environment.NewLine);
                    }
                }
                return script.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}
