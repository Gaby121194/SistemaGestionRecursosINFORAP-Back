using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Extensions
{
    public static class ObjectExtension
    {
        public static string Serialize<T>(this T input) where T : class
        {
            return JsonSerializer.Serialize<T>(input);
        } 
        public static T Deserialize<T>(this string input) where T : class
        {
            return JsonSerializer.Deserialize<T>(input);
        }
    }
}
