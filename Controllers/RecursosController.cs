using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INFORAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecursosController : BaseController
    {
        private readonly IRecursoService _recursoService;
        private readonly IRecursoHumanoService _recursoHumanoService;
        private readonly IRecursoMaterialService _recursoMaterialService;
        private readonly IRecursoRenovableService _recursoRenovableService;
        private readonly IRecursoAsignadoService _recursoAsignadoService;

        public RecursosController(IRecursoService recursoService, IRecursoHumanoService recursoHumanoService, IRecursoMaterialService recursoMaterialService, IRecursoRenovableService recursoRenovableService, IRecursoAsignadoService recursoAsignadoService)
        {
            _recursoService = recursoService;
            _recursoHumanoService = recursoHumanoService;
            _recursoMaterialService = recursoMaterialService;
            _recursoAsignadoService = recursoAsignadoService;
            _recursoRenovableService = recursoRenovableService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entities = await _recursoService.List();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entities = await _recursoService.GetById(id);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecursoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursoService.Create(dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecursoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursoService.Update(id, dto);
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
            await _recursoService.Remove(id);
            return Ok();
        }

        [HttpGet("recursosHumanos/servicios")]
        public async Task<IActionResult> ListRecursosHumanosAvailable(int? idServicio = null)
        {
            try
            {
                var entities = await _recursoHumanoService.ListRecursosHumanosAvailables(Usuario,idServicio);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("recursosMateriales/servicios/{idServicio}")]
        public async Task<IActionResult> ListRecursosMaterialesAvailable(int idServicio)
        {
            try
            {
                var entities = await _recursoMaterialService.ListRecursosMaterialesAvailables(idServicio, Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("recursosAsignados/materiales/To/{idRecurso}")]
        public async Task<IActionResult> ListMaterialesWhereAsignado(int idRecurso) //trae los rr materiales a los cuales esta asignado
        {
            try
            {
                var entities = await _recursoAsignadoService.ListMaterialesWhereAsignado(Usuario, idRecurso);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


            [HttpGet("recursosAsignados/materiales/{id}")]
        public async Task<IActionResult> ListRecursosMaterialesAsignados(int id, string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new RecursoAsignadoFilterDTO(name, creationDateFrom, creationDateTo);
                var entities = await _recursoAsignadoService.ListRRMM(Usuario, id, filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("recursosAsignados/materiales")]
        public async Task<IActionResult> listRRMMFromRecurso(int idRecurso1)
        {
            try
            {
                var entities = await _recursoMaterialService.ListRRMMFromRecurso(idRecurso1, this.Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("recursosAsignados/renovables")]
        public async Task<IActionResult> listRRRRFromRecurso(int idRecurso1)
        {
            try
            {
                var entities = await _recursoRenovableService.ListRRRRFromRecurso(idRecurso1, this.Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("recursosAsignados/renovables/{id}")]
        public async Task<IActionResult> ListRecursosRenovablesAsignados(int id, string name = null, DateTime? creationDateFrom = null, DateTime? creationDateTo = null)
        {
            try
            {
                var filters = new RecursoAsignadoFilterDTO(name, creationDateFrom, creationDateTo);
                var entities = await _recursoAsignadoService.ListRRRR(Usuario, id, filters);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("recursosAsignados/renovables")]
        public async Task<IActionResult> InsertRenovableAsignado(RecursoAsignadoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursoAsignadoService.CreateRRRR(this.Usuario, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("recursosAsignados/materiales")]
        public async Task<IActionResult> InsertMaterialAsignado(RecursoAsignadoDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto = await _recursoAsignadoService.CreateRRMM(this.Usuario, dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("recursosAsignados/{id}")]
        public async Task<IActionResult> DeleteRecursoAsignado(int id)
        {
            await _recursoAsignadoService.Remove(this.Usuario, id);
            return Ok();
        }

        [HttpGet("recursosAsignados/{idRecurso}")]
        public async Task<IActionResult> ListFromResource(int idRecurso, DateTime? fechaAsignadoFrom = null, DateTime? fechaAsignadoTo = null, int? idTipoRecurso = null)
        {
            try
            {
                var filter = new RecursoServicioFilterDTO(fechaAsignadoFrom, fechaAsignadoTo, idTipoRecurso);
                var entities = await _recursoService.ListFromResource(idRecurso, filter, Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        [HttpGet("servicios/{idServicio}")]
        public async Task<IActionResult> ListFromService(int idServicio, DateTime? creationDateFrom = null, DateTime? creationDateTo = null, int? idTipoRecurso = null)
        {
            try
            {
                var filter = new ServicioRecursoFilterDTO(creationDateFrom, creationDateTo, idTipoRecurso);
                var entities = await _recursoService.ListFromService(idServicio,filter, Usuario);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("servicios/{idServicio}")]
        public async Task<IActionResult> InsertServicioRecurso(int idServicio, ServicioRecursoDTO dto)
        {
            try
            {
                if (ValidateServicioRecurso(dto))
                {
                    await _recursoService.InsertServicioRecurso(idServicio, dto, Usuario);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (NotFoundException e) { return NotFound(e.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("servicioRecursos/{idServicioRecurso}")]
        public async Task<IActionResult> RemoveServicioRecurso(int idServicioRecurso)
        {
            try
            {
                await _recursoService.DeleteServicioRecurso(idServicioRecurso, Usuario);
                return Ok();
            }
            catch (NotFoundException e) { return NotFound(e.Message); }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private bool ValidateServicioRecurso(ServicioRecursoDTO dto)
        {
            if (!ModelState.IsValid) return false;
            if (dto.Recurso == null || !dto.Recurso.IdTipoRecurso.HasValue) return false;
            switch ((TipoRecursoEnum)dto.Recurso.IdTipoRecurso.Value)
            {
                case TipoRecursoEnum.Recurso_Humano:
                    {
                        var rrhh = _recursoHumanoService.ListRecursosHumanosAvailables(Usuario,dto.IdServicio).GetAwaiter().GetResult();
                        return rrhh.Any(s => s.IdRecurso == dto.IdRecurso);
                    }
                case TipoRecursoEnum.Recurso_Material:
                    {
                        var rrMat = _recursoMaterialService.ListRecursosMaterialesAvailables(dto.IdServicio, Usuario).GetAwaiter().GetResult();
                        return rrMat.Any(s => s.IdRecurso == dto.IdRecurso);
                    }
                default:
                    return false;
            }


        }
    }
}