using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Authorize()]
    [Route("api/v1/[controller]")]
    public class AlertasController : BaseController
    {
        private readonly IAlertaService _alertaService;

        public AlertasController(IAlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpGet("servicios")]
        public async Task<IActionResult> List()
        {
            try
            {
                var entities = await _alertaService.ListAlertsFor(Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        [HttpGet()]
        public async Task<IActionResult> Count()
        {
            try
            {
                var quantity = await _alertaService.CountAlertsFor(Usuario);
                return Ok(new { quantity = quantity });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}
