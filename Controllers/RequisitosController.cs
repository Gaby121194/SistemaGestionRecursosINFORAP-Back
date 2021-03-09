using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class RequisitosController : BaseController
    {
        private readonly IRequisitoService _requisitoService;

        public RequisitosController(IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
        }

        [HttpGet("servicios/{idServicio}")]
        public async Task<IActionResult> List(int idServicio)
        {
            try
            {
                var entities = await _requisitoService.ListBy(idServicio,Usuario.IdEmpresa);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("servicios/{idServicio}")]
        public async Task<IActionResult> Insert(int idServicio, RequisitoDTO requisito)
        {
            try
            {
                if (IsValid(requisito))
                {
                    requisito = await _requisitoService.Insert(idServicio, requisito, Usuario);
                    return Ok(requisito);
                }
                else return BadRequest(ModelState);
            }
            catch(NotFoundException nf) { return NotFound(nf.Message); }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("{idRequisito}")]
        public async Task<IActionResult> Delete(int idRequisito)
        {
            try
            {
                await _requisitoService.Remove(idRequisito, Usuario);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        private bool IsValid(RequisitoDTO requisito)
        {
            if (!ModelState.IsValid) return false;
            switch (requisito.IdTipoRegla)
            {
                case 1:
                    {
                        return requisito.IdTipoRecurso1.HasValue && requisito.IdTipoRecurso2.HasValue
                             && (requisito.IdTipoRecursoMaterial1.HasValue || requisito.IdTipoRecurso1.Value == TipoRecursoEnum.Recurso_Humano.ToInt())
                             && requisito.IdTipoRecursoMaterial2.HasValue
                             && requisito.Periodicidad.HasValue && requisito.IdUtiempo.HasValue;
                    }
                case 2:
                    {
                        return requisito.IdTipoRecurso1.HasValue && requisito.IdTipoRecurso2.HasValue
                                                    && (requisito.IdTipoRecursoMaterial1.HasValue || requisito.IdTipoRecurso1.Value == TipoRecursoEnum.Recurso_Humano.ToInt())
                                                    && requisito.IdTipoRecursoRenovable.HasValue;
                    }
                case 3:
                    {
                        return requisito.IdTipoRecurso1.HasValue && requisito.IdTipoRecurso2.HasValue
                             && (requisito.IdTipoRecursoMaterial1.HasValue || requisito.IdTipoRecurso1.Value == TipoRecursoEnum.Recurso_Humano.ToInt())
                             && requisito.IdTipoRecursoMaterial2.HasValue;                           
                    }
                case 4:
                    {
                        return requisito.IdTipoRecurso1.HasValue
                             && requisito.IdTipoRecursoMaterial1.HasValue
                             && requisito.Periodicidad.HasValue && requisito.IdUtiempo.HasValue;
                    }
                case 5:
                    {
                        return requisito.IdTipoRecurso1.HasValue
                             && (requisito.IdTipoRecursoMaterial1.HasValue || requisito.IdTipoRecurso1.Value == TipoRecursoEnum.Recurso_Humano.ToInt())
                             && requisito.Periodicidad.HasValue && requisito.IdUtiempo.HasValue;
                    }
                default:
                    return false;
            }
        }

    }
}