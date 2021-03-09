using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TiposRecursosController : ControllerBase
    {
        private readonly ITipoRecursoService _tipoRecursoService;

        public TiposRecursosController(ITipoRecursoService tipoRecursoService)
        {
            _tipoRecursoService = tipoRecursoService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entities = await _tipoRecursoService.List();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entities = await _tipoRecursoService.GetById(id);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoRecursoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _tipoRecursoService.Create(dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoRecursoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _tipoRecursoService.Update(id, dto);
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
            await _tipoRecursoService.Remove(id);
            return Ok();
        }
    }
}