using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize()]
    public class RecursosHumanosController : BaseController
    {
        private readonly IRecursoHumanoService _recursoHumanoService;

        public RecursosHumanosController(IRecursoHumanoService recursoHumanoService)
        {
            _recursoHumanoService = recursoHumanoService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new RecursoHumanoFilterDTO(name, creationDateFrom, creationDateTo, this.Usuario.IdEmpresa);
                var entities = await _recursoHumanoService.List(filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _recursoHumanoService.GetById(this.Usuario, id);
            return Ok(entity);
        }


    

        [HttpPost]
        public async Task<IActionResult> Create(RecursoHumanoDTO entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity = await _recursoHumanoService.Create(this.Usuario, entity);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecursoHumanoDTO entity)
        {
            try { 
            if (ModelState.IsValid)
            {
                entity = await _recursoHumanoService.Update(this.Usuario, id, entity);
                return Ok(entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _recursoHumanoService.Remove(this.Usuario, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable");
            }
        }

        [HttpGet("attributes/{name}")]
        public async Task<IActionResult> Exists(string name, int? id = null)
        {
            try
            {
                var ext = await _recursoHumanoService.Exists(name, this.Usuario.IdEmpresa, id);
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

        [HttpGet("usuarios")]
        public async Task<IActionResult> ListRecursosHumanosWithOutUser(int? idRecursoHumano = null)
        {
            try
            {
                var entities = await _recursoHumanoService.ListRecursosHumanosWithOutUser(this.Usuario, idRecursoHumano);
                return Ok(entities);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
