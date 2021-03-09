using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static INFORAP.API.DTOs.RolDTO;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RolesController : BaseController
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Authorize("admin,manager")]
        public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new RolFilterDTO(name, creationDateFrom, creationDateTo, idEmpresa);
                var entities = await _rolService.List(this.Usuario, this.IsSuperUser, filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }


        }

        [HttpGet("empresas/{id}")]
        public async Task<IActionResult> ListByEmpresaId(int id)
        {
            var entities = await _rolService.ListByEmpresaId(id);
            return Ok(entities);
        }

        [HttpGet("{id}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _rolService.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Create(RolDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _rolService.Create(dto,this.Usuario);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Update(int id, RolDTO rol)
        {
            if (ModelState.IsValid)
            {
                rol = await _rolService.Update(id, rol, this.Usuario);
                return Ok(rol);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolService.Remove(id);
            return Ok();
        }

        [HttpGet("attributes/{name}")]
        [Authorize("admin,manager")]
        public async Task<IActionResult> Exist(string name, int? id=null)
        {
            try
            {
                var ext = await _rolService.Exists(this.Usuario, name, id );
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
