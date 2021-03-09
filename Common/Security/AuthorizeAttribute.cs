using INFORAP.API.Domain.Services;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace INFORAP.API.Common.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Permisos { get; set; }
        private readonly string[] RequiredPermisions;

        public AuthorizeAttribute(string permisos = "")
        {
            Permisos = permisos.ToUpper();
            RequiredPermisions = permisos.ToUpper().Split(',');
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var user = (UsuarioDTO)context.HttpContext.Items["User"];
            var _permisos = (IEnumerable<PermisoDTO>)context.HttpContext.Items["Permisos"];

            if (user == null )
            {
                 context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            //else if (!_permisos.Any(s => Permisos == "" || RequiredPermisions.Contains(s.NombrePermiso.ToUpper())))
            //{
            //    context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
            //    return;
            //}
            else if(DatabaseService.InProgress){
                context.Result = new JsonResult(new { message = "Service Unavailable" }) { StatusCode = StatusCodes.Status503ServiceUnavailable };
                return;
            }
            else
            {
                return;
            }
        }
    }
}
