using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "bad request") : base(message) { }
    }
}
