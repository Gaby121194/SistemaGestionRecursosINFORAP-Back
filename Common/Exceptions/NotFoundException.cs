using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "not found") : base(message) { } 
    }
}
