using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Security
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISecurityConfiguration _appSettings;

        public JwtMiddleware(RequestDelegate next, ISecurityConfiguration appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }
        public async Task Invoke(HttpContext context, IUsuarioService userService, IRolService rolService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachUserToContextAsync(context, userService, rolService, token);
            }

            await _next(context);
        }

        private async Task attachUserToContextAsync(HttpContext context, IUsuarioService userService, IRolService rolService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                var user = await userService.GetIfNotExpiredBy(userId);
                if(user == null)
                {
                    return;
                }

                //var user = jwtToken.Claims.First(x => x.Type == "user").Value.Deserialize<UsuarioDTO>();
                var permisos = jwtToken.Claims.First(x => x.Type == "permisos").Value.Deserialize<IEnumerable<PermisoDTO>>();
                // attach user to context on successful jwt validation

                context.Items["User"] = user;
                context.Items["Permisos"] = permisos;
                if (user.IdRol.HasValue)
                {
                    context.Items["IsSuperUser"] = await rolService.IsSuperUser(user.IdRol.Value);
                }
                else
                {
                    context.Items["IsSuperUser"] = false;
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
