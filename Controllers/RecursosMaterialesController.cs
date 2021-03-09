using System;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("service-user")]
    public class RecursosMaterialesController : BaseController
    {
        private readonly IRecursoMaterialService _recursoMaterialService;

        public RecursosMaterialesController(IRecursoMaterialService recursoMaterialService)
        {
            _recursoMaterialService = recursoMaterialService;
        }


        [HttpGet]
        public async Task<IActionResult> List(string name = null,string idEstado = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new RecursosMaterialesFilterDTO(name, idEstado, creationDateFrom, creationDateTo);
                var entities = await _recursoMaterialService.List(this.Usuario, filters);
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
            var entities = await _recursoMaterialService.GetById(this.Usuario, id);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecursoMaterialDTO dto)
        {
            if (ModelState.IsValid &&
                dto.Marca.Length != 0 && !(dto.Marca.StartsWith(" ")) &&
                dto.Modelo.Length != 0 && !(dto.Modelo.StartsWith(" "))
                )
            {
                        dto = await _recursoMaterialService.Create(this.Usuario, dto);
                        return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecursoMaterialDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursoMaterialService.Update(this.Usuario, id, dto);

                return Ok(dto);
 
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _recursoMaterialService.Remove(this.Usuario, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable");
            }
        }

        [HttpDelete("outofservice/{id}")]
        public async Task<IActionResult> StartOutOfService(int id)
        {
            if (await _recursoMaterialService.StartOutOfService(this.Usuario, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable");
            }
        }

        [HttpGet("outofservice/{id}")]
        public async Task<IActionResult> EndOutOfService(int id)
        {
            if (await _recursoMaterialService.EndOutOfService(this.Usuario, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable");
            }
        }

        [HttpGet("attributes/{name}")]
        [Authorize("service-user")]
        public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _recursoMaterialService.Exists(this.Usuario, name, id);
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
    }
}
