using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class StockRecursoMaterialService : IStockRecursoMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoMaterialRepository;
        private readonly IUbicacionService _ubicacionService;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<RecursoMaterial> _recursoMaterialRepository;

        public StockRecursoMaterialService(IMapper mapper,
            IBaseRepository<StockRecursoMaterial> stockRecursoMaterialRepository,
            IBaseRepository<ServicioRecurso> servicioRecursoRepository,
            IBaseRepository<RecursoAsignado> recursoAsignadoRepository,
            IBaseRepository<RecursoMaterial> recursoMaterialRepository,
            IUbicacionService ubicacionService)
        {
            _mapper = mapper;
            _stockRecursoMaterialRepository = stockRecursoMaterialRepository;
            _ubicacionService = ubicacionService;
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _recursoMaterialRepository = recursoMaterialRepository;
        }
        public async Task<StockRecursoMaterialDTO> Create(UsuarioDTO userLogged, StockRecursoMaterialDTO dto)
        {
            var entity = _mapper.Map<StockRecursoMaterial>(dto);

            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;
            entity.Active = true;
            entity.IdEmpresa = userLogged.IdEmpresa;
            entity.CantidadDisponible = entity.CantidadTotal;
            entity.IdRecursoMaterial = dto.IdRecursoMaterial.Value;

            entity = await _stockRecursoMaterialRepository.Insert(entity);

            var entityDTO = _mapper.Map<StockRecursoMaterialDTO>(entity);

            var recursoMaterial = await _recursoMaterialRepository.GetBy(s => s.Id == dto.IdRecursoMaterial, s => s.IdRecursoNavigation);

            if (await _stockRecursoMaterialRepository.Any(s=> s.Active == true && s.IdRecursoMaterial == recursoMaterial.Id && s.CantidadDisponible > 0 ))
            {

                recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                await _recursoMaterialRepository.Update(recursoMaterial);
            }

            return entityDTO;

        }

        public async Task<StockRecursoMaterialDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _stockRecursoMaterialRepository.GetById(id);

            var entityDTO = _mapper.Map<StockRecursoMaterialDTO>(entity);

            return entityDTO;
        }


        public async Task<IEnumerable<StockRecursoMaterialDTO>> List(UsuarioDTO userlogged, int id, StockRecursoMaterialFilterDTO filter = null)
        {

            var entities = await _stockRecursoMaterialRepository.ListBy(stock =>
            (
                (stock.IdRecursoMaterial == id) &&
                (!filter.CreationDateFrom.HasValue || stock.CreationDate >= filter.CreationDateFrom.Value) &&
                (!filter.CreationDateTo.HasValue || stock.CreationDate <= filter.CreationDateTo.Value) &&

                (
                    filter.Name.IsNullOrEmpty() ||
                    stock.CantidadDisponible.ToString().Contains(filter.Name) ||
                    stock.CantidadTotal.ToString().Contains(filter.Name) ||
                    stock.IdUbicacionNavigation.Referencia.Contains(filter.Name)
                )
            ) &&
            stock.Active == true,
            s => s.IdRecursoMaterialNavigation,
            s => s.IdUbicacionNavigation
            );

            var entitiesDTO = _mapper.Map<IEnumerable<StockRecursoMaterialDTO>>(entities);

            foreach (var item in entitiesDTO)
            {
                item.RefUbicacion = item.IdUbicacionNavigation.Referencia;
            }

            return entitiesDTO;
        }

            public async Task<bool> Remove(int id)
        {
            StockRecursoMaterial entity = await _stockRecursoMaterialRepository.GetBy(s=> s.Id == id, s=> s.IdRecursoMaterialNavigation);

            if (!await _servicioRecursoRepository.Any(s => s.Active == true && s.IdRecurso == entity.IdRecursoMaterialNavigation.IdRecurso && s.IdUbicacion == entity.IdUbicacion)
                && !await _recursoAsignadoRepository.Any(s => s.Active == true && (s.IdRecurso1 == entity.IdRecursoMaterialNavigation.IdRecurso || s.IdRecurso2 == entity.IdRecursoMaterialNavigation.IdRecurso) && s.IdUbicacion == entity.IdUbicacion)
                )
            {
                entity.Active = false;
                entity.RemovalDate = DateTime.Now;

                await _stockRecursoMaterialRepository.Update(id, entity);

                var recursoMaterial = await _recursoMaterialRepository.GetBy(s => s.Id == entity.IdRecursoMaterial, s => s.IdRecursoNavigation);
                if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == recursoMaterial.Id && s.CantidadDisponible > 0))
                {

                    recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                    await _recursoMaterialRepository.Update(recursoMaterial);
                }
                else
                {
                    recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                    await _recursoMaterialRepository.Update(recursoMaterial);
                }

                return true;
            }
            
            else
            {
                return false;
            }


        }

        public async Task<bool> DismiuyeUno(int idUbicacion, int idRecurso)
        {
            var entity = await _stockRecursoMaterialRepository.GetBy(s => s.IdRecursoMaterialNavigation.IdRecursoNavigation.Id == idRecurso && s.IdUbicacion == idUbicacion && s.Active == true);
            if(entity != null && entity.CantidadDisponible > 0)
            {
                entity.CantidadDisponible -= 1;
                await _stockRecursoMaterialRepository.Update(entity.Id, entity);
                return true;
            }

            return false;
        }

        public async Task<bool> AumentaUno(int idUbicacion, int idRecurso)
        {
            var entity = await _stockRecursoMaterialRepository.GetBy(s => s.IdRecursoMaterialNavigation.IdRecursoNavigation.Id == idRecurso && s.IdUbicacion == idUbicacion && s.Active == true);
            if (entity != null && entity.CantidadTotal > entity.CantidadDisponible)
            {
                entity.CantidadDisponible += 1;
                await _stockRecursoMaterialRepository.Update(entity.Id, entity);
                return true;
            }

            return false;
        }

        public async Task<StockRecursoMaterialDTO> Update(UsuarioDTO userLogged, int id, StockRecursoMaterialDTO dto)
        {
            StockRecursoMaterial entity = _mapper.Map<StockRecursoMaterial>(dto);

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;

            var entityOG = await _stockRecursoMaterialRepository.GetById(id);

            entity.CreationDate = entityOG.CreationDate;
            entity.CreationUserId = entityOG.CreationUserId;
            entity.Active = true;
            entity.IdEmpresa = userLogged.IdEmpresa;

            if (dto.CantidadTotal < entityOG.CantidadDisponible)
            {
                entity.CantidadDisponible = entity.CantidadTotal - (entityOG.CantidadTotal - entityOG.CantidadDisponible);
            }
            else
            {
                entity.CantidadDisponible = entityOG.CantidadDisponible + (entity.CantidadTotal - entityOG.CantidadTotal);
            }

            entity = await _stockRecursoMaterialRepository.Update(id, entity);

            var entityDTO = _mapper.Map<StockRecursoMaterialDTO>(entity);

            var recursoMaterial = await _recursoMaterialRepository.GetBy(s => s.Id == dto.IdRecursoMaterial, s => s.IdRecursoNavigation);

            if (await _stockRecursoMaterialRepository.Any(s => s.Active == true && s.IdRecursoMaterial == recursoMaterial.Id && s.CantidadDisponible > 0))
            {

                recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
                await _recursoMaterialRepository.Update(recursoMaterial);
            }
            else
            {
                recursoMaterial.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
                await _recursoMaterialRepository.Update(recursoMaterial);
            }

            return entityDTO;
        }
        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _stockRecursoMaterialRepository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.IdUbicacionNavigation.Id.ToString() == name &&
                   s.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            ));
        }
    }
}
