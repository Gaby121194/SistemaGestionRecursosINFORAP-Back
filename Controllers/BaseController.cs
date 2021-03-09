using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public UsuarioDTO Usuario { get =>   HttpContext.Items["User"] as UsuarioDTO; } 
        public bool IsSuperUser { get => Convert.ToBoolean(HttpContext.Items["IsSuperUser"]); }
    }
}
