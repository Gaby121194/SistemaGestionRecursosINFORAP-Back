using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TiposReglasController : ControllerBase
    {

        private readonly ITipoReglaService _tipoReglaService;

        public TiposReglasController(ITipoReglaService tipoReglaService)
        {
            _tipoReglaService = tipoReglaService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entities = await _tipoReglaService.List();
            return Ok(entities);
        }
 
    }
}