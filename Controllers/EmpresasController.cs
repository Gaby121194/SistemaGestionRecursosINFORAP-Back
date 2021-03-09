using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using INFORAP.API.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize()]
    public class EmpresasController : BaseController
    {
        private readonly IEmpresaService _empresaService;

        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        [Authorize("admin")]
        public async Task<IActionResult> List(string name = null, string active = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new EmpresaFilterDTO(name, active, creationDateFrom, creationDateTo, idEmpresa);
                var entities = await _empresaService.List(filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }


        }


        [HttpGet("activate/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> Activate(int id)
        {
            var entity = await _empresaService.Activate(id);
            return Ok(entity);
        }

        [HttpGet("{id}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _empresaService.GetById(this.Usuario, this.IsSuperUser, id);
            return Ok(entity);
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<IActionResult> Create(EmpresaDTO empresa)
        {
            if (ModelState.IsValid)
            {
                empresa = await _empresaService.Create(this.Usuario, empresa);
                return Ok(empresa);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Update(int id, EmpresaDTO empresa)
        {
            if (ModelState.IsValid)
            {
                empresa = await _empresaService.Update(this.Usuario, id, empresa);
                return Ok(empresa);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresaService.Remove(id);
            return Ok();
        }

        [HttpGet("attributes/{name}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Exist(string name, int? id = null)
        {
            try
            {
                var ext = await _empresaService.Exists(name, id);
                return Ok(new
                {
                    valid = !ext
                });
            }
            catch (Exception e)
            {
              return  StatusCode(500, e.Message);
            }
        }


    }
}
