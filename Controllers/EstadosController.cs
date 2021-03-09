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
    public class EstadosController : ControllerBase
    {
        
            private readonly IEstadoService _estadoService;

            public EstadosController(IEstadoService estadoService)
            {
                _estadoService = estadoService;
            }


            [HttpGet]
            public async Task<IActionResult> List()
            {
                var entities = await _estadoService.List();
                return Ok(entities);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var entities = await _estadoService.GetById(id);
                return Ok(entities);
            }

            [HttpPost]
            public async Task<IActionResult> Create(EstadoDTO dto)
            {
                if (ModelState.IsValid)
                {
                    dto = await _estadoService.Create(dto);
                    return Ok(dto);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, EstadoDTO dto)
            {
                if (ModelState.IsValid)
                {
                    dto = await _estadoService.Update(id, dto);
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
                await _estadoService.Remove(id);
                return Ok();
            }
        }

    
}