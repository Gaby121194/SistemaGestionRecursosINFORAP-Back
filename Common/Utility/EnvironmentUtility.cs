using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Utility
{
    public static class LaunchSettingstUtility
    {
        public static string GetEnvironmentVariableFromJSON(string variable, string profile = "IIS Express")
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "properties");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                             .SetBasePath(basePath)
                             .AddJsonFile("launchSettings.json")
                             .Build();
            var value = configuration.GetSection($"profiles:{profile}:environmentVariables")[variable];
            Console.WriteLine("conn: " + value);
            return value;

        }
    }
}
