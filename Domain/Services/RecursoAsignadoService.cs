using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class RecursoAsignadoService : IRecursoAsignadoService
    {
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<Recurso> _recursoRepository;
        private readonly IStockRecursoMaterialService _stockRecursoMaterialService;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoMaterialRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<RecursoMaterial> _RecursoMaterialRespository;
        private readonly IBaseRepository<RecursoRenovable> _recursoRenovableRepository;

        public RecursoAsignadoService
        (
            IMapper mapper,
            IBaseRepository<RecursoAsignado> recursoAsignadoRepository,
            IStockRecursoMaterialService stockRecursoMaterialService,
            IBaseRepository<Recurso> recursoRepository,
            IBaseRepository<RecursoMaterial> recursoMaterial,
            IBaseRepository<RecursoRenovable> recursoRenovable,
            IBaseRepository<StockRecursoMaterial> stockRecursoMaterialRepository
        ) 
        {
            _stockRecursoMaterialRepository = stockRecursoMaterialRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _recursoRepository = recursoRepository;
            _stockRecursoMaterialService = stockRecursoMaterialService;
            _mapper = mapper;
            _RecursoMaterialRespository = recursoMaterial;
            _recursoRenovableRepository = recursoRenovable;


        }
        public async Task<RecursoAsignadoDTO> CreateRRMM(UsuarioDTO userLogged, RecursoAsignadoDTO dto)
        {
            var entity = _mapper.Map<RecursoAsignado>(dto);
            /*entity.IdRecurso1 = (await _RecursoMaterialRespository.GetBy(s => s.Id == entity.IdRecurso1)).IdRecurso;*/
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.Active = true;
            entity.FechaAsignado = DateTime.Now;

            var recursoMaterial = await _RecursoMaterialRespository.GetBy(s=> s.IdRecursoNavigation.Id == dto.IdRecurso2, s=> s.IdRecursoNavigation);

            if (recursoMaterial.Stockeable == true)
            {
                bool bajar = await _stockRecursoMaterialService.DismiuyeUno((int)dto.IdUbicacion, recursoMaterial.IdRecursoNavigation.Id);
                if (!bajar)
                {
                    throw new NotFoundException();
                }
                
                if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == recursoMaterial.Id && s.CantidadDisponible > 0))
                {

                    recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                    await _RecursoMaterialRespository.Update(recursoMaterial);
                }
                else
                {
                    recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                    await _RecursoMaterialRespository.Update(recursoMaterial);
                }
            }
            else
            {
                var recurso = await _recursoRepository.GetById(dto.IdRecurso2);
                recurso.IdEstado = EstadosEnum.Asignado.ToInt();
                await _recursoRepository.Update(recurso);
            }
            entity = await _recursoAsignadoRepository.Insert(entity);
            return _mapper.Map<RecursoAsignadoDTO>(entity);


        }

        public async Task<RecursoAsignadoDTO> CreateRRRR(UsuarioDTO userLogged, RecursoAsignadoDTO dto)
        {
            var entity = _mapper.Map<RecursoAsignado>(dto);
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.Active = true;
            entity.FechaAsignado = DateTime.Now;

            entity = await _recursoAsignadoRepository.Insert(entity);

            var recurso = await _recursoRepository.GetBy(s => s.Id == entity.IdRecurso2);
            recurso.IdEstado = EstadosEnum.Asignado.ToInt();
            await _recursoRepository.Update(recurso);

            return _mapper.Map<RecursoAsignadoDTO>(entity);


        }

        public async Task<RecursoAsignadoDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _recursoAsignadoRepository.GetBy(s => s.Id == id);

            return _mapper.Map<RecursoAsignadoDTO>(entity);
        }

        public async Task<IEnumerable<RecursoAsignadoDTO>> ListRRMM(UsuarioDTO userlogged, int idRecurso, RecursoAsignadoFilterDTO filter = null)
        {

            var entitiesDTO = new List<RecursoAsignadoDTO>();

            var entitiesRRMM = await _recursoAsignadoRepository.ListBy(recursoAsignado =>
                recursoAsignado.Active == true 
                && (recursoAsignado.IdRecurso1 == idRecurso )
                && recursoAsignado.IdRecurso2Navigation.IdTipoRecursoNavigation.Id == TipoRecursoEnum.Recurso_Material.ToInt()
                && (!filter.CreationDateFrom.HasValue || recursoAsignado.CreationDate >= filter.CreationDateFrom.Value)
                && (!filter.CreationDateTo.HasValue || recursoAsignado.CreationDate <= filter.CreationDateTo.Value) &&

                    (
                        filter.Name.IsNullOrEmpty() ||
                        recursoAsignado.IdRecurso2Navigation.RecursoMaterial.FirstOrDefault().Marca.ToLower().Contains(filter.Name) ||
                        recursoAsignado.IdRecurso2Navigation.RecursoMaterial.FirstOrDefault().Modelo.ToLower().Contains(filter.Name) ||
                        recursoAsignado.IdRecurso2Navigation.RecursoMaterial.FirstOrDefault().IdTipoRecursoMaterialNavigation.Descripcion.ToLower().Contains(filter.Name) ||
                        recursoAsignado.IdUbicacionNavigation.Referencia.ToLower().Contains(filter.Name)
                    )
                ,
                s => s.IdRecurso2Navigation.RecursoMaterial,
                s => s.IdUbicacionNavigation
            );;

            foreach (var item in entitiesRRMM)
            {
                
                var result = new RecursoAsignadoDTO
                {
                    ReferenciaUbicacion = item.IdUbicacionNavigation?.Referencia,

                    Id = item.Id,
                    IdRecurso1 = item.IdRecurso1,
                    IdRecurso2 = item.IdRecurso2,
                    FechaAsignado = item.FechaAsignado,
                    IdUbicacion = item.IdUbicacion,
                    
                    recursoMaterial = _mapper.Map<RecursoMaterialDTO>(await _RecursoMaterialRespository.GetBy
                (
                    s => s.IdRecurso == item.IdRecurso2,
                    s => s.IdTipoRecursoMaterialNavigation
                ))
                };
                entitiesDTO.Add(result);
            }

            return entitiesDTO;

        }

        public async Task<IEnumerable<RecursoAsignadoDTO>> ListRRRR(UsuarioDTO userlogged, int idRecurso, RecursoAsignadoFilterDTO filter = null)
        {

            var entitiesDTO = new List<RecursoAsignadoDTO>();

            var entitiesRRRR = await _recursoAsignadoRepository.ListBy(recursoAsignado =>
                recursoAsignado.Active == true
                && (recursoAsignado.IdRecurso1 == idRecurso)
                && recursoAsignado.IdRecurso2Navigation.IdTipoRecursoNavigation.Id == TipoRecursoEnum.Recurso_Renovable.ToInt()
                && (!filter.CreationDateFrom.HasValue || recursoAsignado.CreationDate >= filter.CreationDateFrom.Value)
                && (!filter.CreationDateTo.HasValue || recursoAsignado.CreationDate <= filter.CreationDateTo.Value) &&

                    (
                        filter.Name.IsNullOrEmpty() ||
                       recursoAsignado.IdRecurso2Navigation.Descripcion.ToLower().Contains(filter.Name) ||
                        recursoAsignado.IdRecurso2Navigation.RecursoRenovable.FirstOrDefault().FechaVencimiento.ToShortDateString().ToLower().Contains(filter.Name) ||
                        recursoAsignado.IdUbicacionNavigation.Referencia.ToLower().Contains(filter.Name)
                    )
                ,
                s => s.IdRecurso2Navigation.RecursoRenovable,
                s => s.IdUbicacionNavigation
            ); ;

            foreach (var item in entitiesRRRR)
            {

                var result = new RecursoAsignadoDTO
                {
                    ReferenciaUbicacion = item.IdUbicacionNavigation?.Referencia,

                    Id = item.Id,
                    IdRecurso1 = item.IdRecurso1,
                    IdRecurso2 = item.IdRecurso2,
                    FechaAsignado = item.FechaAsignado,
                    IdUbicacion = item.IdUbicacion,

                    recursoRenovable = _mapper.Map<RecursoRenovableDTO>(await _recursoRenovableRepository.GetBy
                (
                    s => s.IdRecurso == item.IdRecurso2,
                    s => s.IdTipoRecursoRenovableNavigation
                ))
                };
                entitiesDTO.Add(result);
            }

            return entitiesDTO;

        }


        public async Task<IEnumerable<RecursoAsignadoDTO>> ListMaterialesWhereAsignado(UsuarioDTO userlogged, int idRecurso)
        {


            var entitiesRRRR = await _recursoAsignadoRepository.ListBy(recursoAsignado =>
                recursoAsignado.Active == true
                && (recursoAsignado.IdRecurso2 == idRecurso)
            ); ;

            return _mapper.Map<IEnumerable<RecursoAsignadoDTO>>(entitiesRRRR);

        }



        public async Task Remove(UsuarioDTO loggedUser, int id)
        {
            var entity = await _recursoAsignadoRepository.GetBy(s => s.Id == id);
            entity.Active = false;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = loggedUser.Id;

            var recurso = await _recursoRepository.GetBy(s => s.Id == entity.IdRecurso2);

            if(!await _recursoAsignadoRepository.Any(s=> s.Active && s.IdRecurso2 == recurso.Id && s.Id != entity.Id) )
                // si no esta asignado a ningun otro recurso, se lo pone como disponible
            {
                recurso.IdEstado = EstadosEnum.Disponible.ToInt();

            }
            if (recurso.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt())
            {
                var recursoMaterial = await _RecursoMaterialRespository.GetBy(s => s.IdRecurso == entity.IdRecurso2);
                if ((bool)recursoMaterial.Stockeable)
                {
                    await _stockRecursoMaterialService.AumentaUno((int)entity.IdUbicacion, entity.IdRecurso2);
                    if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == recursoMaterial.Id && s.CantidadDisponible > 0))
                    {

                        recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                        await _RecursoMaterialRespository.Update(recursoMaterial);
                    }
                    else
                    {
                        recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                        await _RecursoMaterialRespository.Update(recursoMaterial);
                    }
                }

            }
           

            await _recursoRepository.Update(recurso);


            await _recursoAsignadoRepository.Update(id, entity);
        }

        public async Task<RecursoAsignadoDTO> Update(UsuarioDTO userLogged, int id, RecursoAsignadoDTO dto)
        {
            var entity = _mapper.Map<RecursoAsignado>(dto);
            var entityOG = await _recursoAsignadoRepository.GetBy(s => s.Id == id);

            entity.Active = true;
            entity.CreationDate = entityOG.CreationDate;
            entity.CreationUserId = entityOG.CreationUserId;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;

            entity = await _recursoAsignadoRepository.Update(id, entity);
            return _mapper.Map<RecursoAsignadoDTO>(entity); ;
        }
    }
}
