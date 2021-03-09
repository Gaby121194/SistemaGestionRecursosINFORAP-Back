using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static INFORAP.API.DTOs.RecursoRenovableDTO;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("SERVICE-USER")]
    public class RecursosRenovablesController : BaseController
    {
        private readonly IRecursoRenovableService _recursosRenovablesService;

        public RecursosRenovablesController(IRecursoRenovableService recursoRenovableService)
        {
            _recursosRenovablesService = recursoRenovableService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string name = null, string idEstado = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new RecursosRenovablesFilterDTO(name, idEstado, creationDateFrom, creationDateTo);
                var entities = await _recursosRenovablesService.List(this.Usuario, filters);
                return Ok(entities);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entities = await _recursosRenovablesService.GetById(this.Usuario, id);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecursoRenovableDTO dto)
        {
            if (ModelState.IsValid &&
                dto.Descripcion.Length != 0 && !dto.Descripcion.StartsWith(" ")
                )
            {

                dto = await _recursosRenovablesService.Create(dto, this.Usuario);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecursoRenovableDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursosRenovablesService.Update(this.Usuario, id, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("attributes/{name}")]
        
        public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _recursosRenovablesService.Exists(this.Usuario, name, id);
                return Ok(new
                {
                    valid = !ext
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            { await _recursosRenovablesService.Remove(this.Usuario, id);
              
                return Ok();
            }
            catch (BadRequestException bd)
            {

                return BadRequest(new { mensaje = bd.Message});
            }
        }
    }
}