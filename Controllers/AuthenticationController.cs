using INFORAP.API.Common.Security;
using INFORAP.API.Common.Utility;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMailClient _mailClient;

        public AuthenticationController(IAuthenticationService authService, IUsuarioService usuarioService, IMailClient mailClient)
        {
            _authService = authService;
            _usuarioService = usuarioService;
            _mailClient = mailClient;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationDTO dto)
        {
            var token = await _authService.Authenticate(dto);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }


        [HttpGet("{userName}")]
        public async Task<IActionResult> RecoveryPassword(string userName)
        {
            var user = await _usuarioService.GetBy(userName);
            if (user != null)
            {
                var nwPsw = Guid.NewGuid().ToString().Substring(0, 8);
                await _usuarioService.UpdatePassword(user.Id, nwPsw);
                var nombre = user.Nombre + ", " + user.Apellido;
                var body = $"Estimado {nombre}:" + Environment.NewLine +
                    "Se ha cambiado la contraseña de acceso a Inforap"
                    + Environment.NewLine +
                    $"Su nueva contraseña es: {nwPsw} ";
                _mailClient.Send(user.Email, nombre, "Recuperación de contraseña", body);

            }
            return Ok();


        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListFuncionalidad()
        {
            try
            {
                IEnumerable<ControladorDTO> views = new List<ControladorDTO>();
                if (Usuario.IdRol.HasValue)
                    views = await this._authService.GetViews(this.Usuario.IdRol.Value);
                return Ok(views);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
          
        }
    }
}