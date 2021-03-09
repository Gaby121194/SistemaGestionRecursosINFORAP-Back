using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Authorize()]
    [Route("api/v1/[controller]")]
    public class FuncionalidadController : BaseController
    {
        private readonly IControladorService _controladorService;

        public FuncionalidadController(IControladorService controladorService)
        {
            _controladorService = controladorService;
        }

        [HttpGet()]
        public async Task<IActionResult> List(string name = "", DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var entities = await _controladorService.List(new ControladorFilterDTO(name, creationDateFrom, creationDateTo));
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            try
            {
                var entity = await _controladorService.GetBy(id);
                return Ok(entity);
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ControladorDTO dto)
        {
            try
            {
                var entity = await _controladorService.Insert(dto, Usuario);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ControladorDTO dto)
        {
            try
            {
                var entity = await _controladorService.Update(dto, id, Usuario);
                return Ok(entity);
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _controladorService.Disable(id, Usuario);
                return Ok();
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _controladorService.Enable(id, Usuario);
                return Ok();
            }
            catch (NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("attributes/{key}/{value}")]
        public async Task<object> Exist(string key, string value, int? id = null)
        {
            bool ext = true;
            switch (key.ToLower())
            {
                case "url":
                    {
                        ext = await _controladorService.ExistUrl(value, id);
                        break;
                    }
                case "display":
                    {
                        ext = await _controladorService.ExistDisplay(value, id);
                        break;
                    }
                default:
                    break;
            }

            return Ok(new
            {
                valid = !ext
            });
        }

    }
}
