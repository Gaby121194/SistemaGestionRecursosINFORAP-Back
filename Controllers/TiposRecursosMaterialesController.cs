using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("service-user")]
    public class TiposRecursosMaterialesController : BaseController
    {
        private readonly ITipoRecursoMaterialService _tipoRecursoMaterialService;

        public TiposRecursosMaterialesController(ITipoRecursoMaterialService tipoRecursoMaterialService)
        {
            _tipoRecursoMaterialService = tipoRecursoMaterialService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new TipoRecursoMaterialFilterDTO(name, creationDateFrom, creationDateTo);
                var entities = await _tipoRecursoMaterialService.List(this.Usuario, filters);
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
            var entities = await _tipoRecursoMaterialService.GetById(this.Usuario, id);
            return Ok(entities);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TipoRecursoMaterialDTO dto)
        {
            if (ModelState.IsValid &&
                dto.Descripcion.Length != 0 && !(dto.Descripcion.StartsWith(" "))
                )
            {
                dto = await _tipoRecursoMaterialService.Create(this.Usuario, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoRecursoMaterialDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _tipoRecursoMaterialService.Update(this.Usuario, id, dto);
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

            if (await _tipoRecursoMaterialService.Remove(this.Usuario, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable");
            }
        }

        [HttpGet("attributes/{name}")]
        public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _tipoRecursoMaterialService.Exists(this.Usuario, name, id);
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
