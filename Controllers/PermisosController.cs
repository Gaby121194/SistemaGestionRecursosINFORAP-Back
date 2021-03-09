using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PermisosController : BaseController
    {
        private readonly IPermisoService _permisoService;

        public PermisosController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpGet]     
        public async Task<IActionResult> List(string name = "", DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            if (IsSuperUser)
            {
                return Ok(await _permisoService.List(new PermisoFilterDTO(name,creationDateFrom,creationDateTo),true));
            }
            else
            {
                return Ok(await _permisoService.List());
            }        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            try
            {
                return Ok(await _permisoService.GetBy(id));
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
             
          
        }
        [HttpPost()]
        public async Task<IActionResult> Create(PermisoDTO dto)
        {
            try
            {
                var entity = await _permisoService.Insert(dto, Usuario);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PermisoDTO dto)
        {
            try
            {
                var entity = await _permisoService.Update(dto, id, Usuario);
                return Ok(entity);
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _permisoService.Disable(id, Usuario);
                return Ok();
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _permisoService.Enable(id, Usuario);
                return Ok();
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("attributes/{value}")]
        public async Task<object> Exist(string value, int? id = null)
        {
            var ext = await _permisoService.Exist(value, id); ;        
            return Ok(new
            {
                valid = !ext
            });
        }

    }
}
