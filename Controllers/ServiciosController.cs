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
    public class ServiciosController : BaseController
    {
        private readonly IServicioService _servicioService;
        private readonly IMotivoBajaServicioService _motivoBajaServicioService;

        public ServiciosController(IServicioService servicioService, IMotivoBajaServicioService motivoBajaServicioService)
        {
            _servicioService = servicioService;
            _motivoBajaServicioService = motivoBajaServicioService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string name = "", DateTime? fechaInicioFrom = null, DateTime? fechaInicioTo = null, DateTime? fechaFinFrom = null, DateTime? fechaFinTo = null)
        {
            var filter = new ServicioFilterDTO(name, fechaInicioFrom, fechaInicioTo, fechaFinFrom, fechaFinTo);
            var entities = await _servicioService.ListBy(Usuario.IdEmpresa, filter);
            return Ok(entities);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var entity = await _servicioService.GetBy(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ServicioDTO servicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicio = await _servicioService.Create(servicio, Usuario);
                    return Ok(servicio);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Insert(int id, ServicioDTO servicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicio = await _servicioService.Update(id, servicio, Usuario);
                    return Ok(servicio);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}/motivoBajaServicios/{idMotivoBaja}")]
        public async Task<IActionResult> Delete(int id, int idMotivoBaja, string observaciones = "")
        {
            try
            {
                await _servicioService.Remove(id, idMotivoBaja,observaciones, Usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("attributes/{value}")]
        public async Task<object> Exist(string value, int? id = null)
        {
            var ext = await _servicioService.Exists(value, Usuario.IdEmpresa, id);
            return Ok(new
            {
                valid = !ext
            });
        }

        [HttpGet("contratos")]
        public async Task<object> GenerateContractNumber()
        {
            var contractNumber = await _servicioService.GenerateContractNumber(Usuario.IdEmpresa);
            return Ok(new
            {
                contractNumber = contractNumber
            });
        }

        [HttpGet("motivoBajaServicios")]
        public async Task<IActionResult> ListMotivosBaja()
        {
            try
            {
                var entities = await _motivoBajaServicioService.List();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }

        }
        [HttpGet("analitycs/recursoshumanos/{idServicio}/{from}/{to}")]
        public async Task<IActionResult> GetHumanResourcesGroupedByMonths(int idServicio,DateTime from, DateTime to)
        {
            try
            {
                var entities = await _servicioService.GetHumanResourcesGroupedByMonths(from, to ,idServicio,Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        } 
        [HttpGet("analitycs/activos/{from}/{to}")]
        public async Task<IActionResult> GetActiveServicesGroupedByMonths(DateTime from, DateTime to)
        {
            try
            {
                var entities = await _servicioService.GetActiveServicesGroupedByMonths(from, to ,Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpGet("analitycs/activos/inactivos/{from}/{to}")]
        public async Task<IActionResult> GetServiciosActivosInactivos(DateTime from, DateTime to)
        {
            try
            {
                var entities = await _servicioService.GetServiciosActivosInactivos(from, to ,Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        } 
        [HttpGet("analitycs/inactivos/{from}/{to}")]
        public async Task<IActionResult> GetServiciosInactivosMotivos(DateTime from, DateTime to)
        {
            try
            {
                var entities = await _servicioService.GetServiciosInactivosMotivos(from, to ,Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
