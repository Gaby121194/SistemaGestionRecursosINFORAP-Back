using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize()]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize("admin,manager")]
        public async Task<IActionResult> List(string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idEmpresa = null)
        {
            try
            {
                var filters = new UsuarioFilterDTO(name, creationDateFrom, creationDateTo, idEmpresa);
                var entities = await _usuarioService.List(this.Usuario, this.IsSuperUser,filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var entity = await _usuarioService.GetBy(id);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = await _usuarioService.Update(this.Usuario, id, user);
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

        [HttpPost()]
        public async Task<IActionResult> Insert(UsuarioDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = await _usuarioService.Insert(this.Usuario, user);
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
            await _usuarioService.Remove(id, this.Usuario);
            return Ok();
        }

        [HttpGet("attributes/{username}")]
        public async Task<IActionResult> Exist(string username)
        {
            var ext = await _usuarioService.Exists(username);
            return Ok(new
            {
                valid = !ext
            });
        }
    }
}