using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("service-user")]
    public class StockRecursosMaterialesController : BaseController
    {
        private readonly IStockRecursoMaterialService _stockRecursoMaterialService;

        public StockRecursosMaterialesController(IStockRecursoMaterialService stockRecursoMaterialService)
        {
            _stockRecursoMaterialService = stockRecursoMaterialService;
        }

        [HttpGet("recursoMaterial/{id}")]
        public async Task<IActionResult> List(int id, string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new StockRecursoMaterialFilterDTO(name, creationDateFrom, creationDateTo);
                var entities = await _stockRecursoMaterialService.List(this.Usuario, id, filters);
                return Ok(entities);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var entities = await _stockRecursoMaterialService.GetById(this.Usuario, id);
            return Ok(entities);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mia = await _stockRecursoMaterialService.Remove(id);
            if (mia)
            {
                return Ok();
            } else
            {
                return BadRequest("No se puede");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create(StockRecursoMaterialDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _stockRecursoMaterialService.Create(this.Usuario, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StockRecursoMaterialDTO dto)
        {
            if (ModelState.IsValid)
            {
                var entity = await _stockRecursoMaterialService.Update(this.Usuario, id, dto);
                return Ok(entity);
            }else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpGet("attributes/{name}")]
        public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _stockRecursoMaterialService.Exists(this.Usuario, name, id);
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
