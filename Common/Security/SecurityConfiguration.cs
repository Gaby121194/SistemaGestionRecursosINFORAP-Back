using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Security
{
    public class SecurityConfiguration : ISecurityConfiguration
    {
        public string Secret { get; set; }
        public string EmailFrom { get; set; }
        public string PswFrom { get; set; }
    }
    public interface ISecurityConfiguration
    {
        public string Secret { get; set; }
        public string EmailFrom { get; set; }
        public string PswFrom { get; set; }
    }
}
