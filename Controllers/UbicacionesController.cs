using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize()]
    public class UbicacionesController : BaseController
    {
        private readonly IUbicacionService _ubicacionService;
        public UbicacionesController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet]
         public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new UbicacionFilterDTO(name, creationDateFrom, creationDateTo, idEmpresa);
                var entities = await _ubicacionService.List(this.Usuario, filters);
                return Ok(entities);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("stockrecursomaterial/{id}")]
         public async Task<IActionResult> ListByRecursoMaterial(int id)
        {
            var entity = await _ubicacionService.ListByRecursoMaterial(this.Usuario, id);
            return Ok(entity);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetById(int id)
        {
            var entity = await _ubicacionService.GetById(this.Usuario, id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UbicacionDTO ubicacion)
        {
            if (ModelState.IsValid)
            {
                ubicacion = await _ubicacionService.Create(this.Usuario, ubicacion);
                return Ok(ubicacion);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UbicacionDTO ubicacion)
        {
            if (ModelState.IsValid)
            {
                ubicacion = await _ubicacionService.Update(this.Usuario,  id, ubicacion);
                return Ok(ubicacion);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpDelete("{id}")]
         public async Task<IActionResult> Delete( int id)
        {
            if( await _ubicacionService.Remove(this.Usuario, id))
            {
                return Ok();
            } else
            {
                return BadRequest("No se pudo");
            }
          
        }

        [HttpGet("attributes/{name}")]
         public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _ubicacionService.Exists(this.Usuario, name, id);
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

