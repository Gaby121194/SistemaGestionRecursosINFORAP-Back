using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("service-user")]
    public class ClientesController : BaseController
    {

        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new ClienteFilterDTO(name, creationDateFrom, creationDateTo, idEmpresa);
                var entities = await _clienteService.List(this.Usuario, filters);
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
            var entity = await _clienteService.GetById(this.Usuario, id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _clienteService.Create(this.Usuario, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _clienteService.Update(this.Usuario, id, dto);
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

            if (await _clienteService.Remove(this.Usuario, id))
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
                var ext = await _clienteService.Exists(this.Usuario, name, id);
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
