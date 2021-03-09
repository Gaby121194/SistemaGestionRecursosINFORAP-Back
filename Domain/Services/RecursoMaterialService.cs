using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class RecursoMaterialService : IRecursoMaterialService
    {
        private readonly IBaseRepository<RecursoMaterial> _RecursoMaterialRespository;
        private readonly IStockRecursoMaterialService _stockRecursoMaterialService;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<StockRecursoMaterial> _stockRecursoMaterialRepository;
        private readonly IMapper _mapper;

        public RecursoMaterialService(IMapper mapper,
            IBaseRepository<RecursoMaterial> RecursoMaterialRespository,
            IBaseRepository<TipoRecursoMaterial> TipoRecursoMaterialRepository,
            IBaseRepository<Recurso> RecursoRepository,
            IBaseRepository<Ubicacion> UbicacionRepository,
            IBaseRepository<TipoRecurso> TipoRecursoRepository,
            IBaseRepository<Estado> EstadoRepository,
            ITipoRecursoMaterialService tipoRecursoMaterialService,
            IStockRecursoMaterialService stockRecursoMaterialService,
            IRecursoService recursoService,
            IBaseRepository<ServicioRecurso> servicioRecursoRepository,
            IBaseRepository<RecursoAsignado> recursoAsignadoRepository,
            IBaseRepository<StockRecursoMaterial> stockRecursoMaterialRepository
            )
        {
            _RecursoMaterialRespository = RecursoMaterialRespository;
            _stockRecursoMaterialService = stockRecursoMaterialService;
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;

            _mapper = mapper;
            _stockRecursoMaterialRepository = stockRecursoMaterialRepository;
        }

        public async Task<RecursoMaterialDTO> Create(UsuarioDTO userLogged, RecursoMaterialDTO dto)
        {
            var entity = _mapper.Map<RecursoMaterial>(dto);

            entity.IdRecursoNavigation = new Recurso
            {
                Active = true,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreationUserId = userLogged.Id,
                UpdateUserId = userLogged.Id,
                IdEmpresa = userLogged.IdEmpresa,
                IdEstado = EstadosEnum.Disponible.ToInt(),
                IdTipoRecurso = TipoRecursoEnum.Recurso_Material.ToInt(),
            };
            entity.Multiservicio = dto.Multiservicio;
            entity.Stockeable = dto.Stockeable;
            entity.Active = true;

            entity = await _RecursoMaterialRespository.Insert(entity);

            return _mapper.Map<RecursoMaterialDTO>(entity);
        }

        public async Task<RecursoMaterialDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _RecursoMaterialRespository.GetBy
                (
                    s => s.Id == id,
                    s => s.IdRecursoNavigation.IdEstadoNavigation,
                    s => s.IdTipoRecursoMaterialNavigation
                );

            var result = _mapper.Map<RecursoMaterialDTO>(entity);

            result.boolAsignados = await _recursoAsignadoRepository.Any(s => s.IdRecurso1 == entity.IdRecurso && s.Active == true);

            return result;
        }

        public async Task<IEnumerable<RecursoMaterialDTO>> List(UsuarioDTO userlogged, RecursosMaterialesFilterDTO filter = null)
        {
            var entities = await _RecursoMaterialRespository.ListBy(recursoMaterial =>
                (
                    (recursoMaterial.IdRecursoNavigation.IdEmpresa == userlogged.IdEmpresa) &&
                    (!filter.CreationDateFrom.HasValue || recursoMaterial.IdRecursoNavigation.CreationDate >= filter.CreationDateFrom.Value) &&
                    (!filter.CreationDateTo.HasValue || recursoMaterial.IdRecursoNavigation.CreationDate <= filter.CreationDateTo.Value) &&
                    (filter.IdEstado.IsNullOrEmpty() || recursoMaterial.IdRecursoNavigation.IdEstado.ToString() == filter.IdEstado) &&

                    (
                        filter.Name.IsNullOrEmpty() ||
                        recursoMaterial.Marca.ToLower().Contains(filter.Name) ||
                        recursoMaterial.Modelo.ToLower().Contains(filter.Name) ||
                        recursoMaterial.IdRecursoNavigation.IdEstadoNavigation.Descripcion.ToLower().Contains(filter.Name) ||
                        recursoMaterial.IdTipoRecursoMaterialNavigation.Descripcion.ToLower().Contains(filter.Name)
                    )
                ) &&
            recursoMaterial.IdRecursoNavigation.Active == true,
            s => s.IdRecursoNavigation.IdEstadoNavigation,
            s => s.IdTipoRecursoMaterialNavigation,
            s => s.FueraServicio
            );

            var entitiesDTO = new List<RecursoMaterialDTO>();
            foreach (var item in entities)
            {
                var result = _mapper.Map<RecursoMaterialDTO>(item);

                var fueraServicioItem = (await _RecursoMaterialRespository.GetBy(s => s.Id == item.Id)).FueraServicio;

                if (fueraServicioItem.Any(s => s.Active))
                {
                    result.fechaInicioFueraServicio = fueraServicioItem.LastOrDefault().FechaInicio;
                }
                entitiesDTO.Add(result);

            }

            return entitiesDTO;
        }
        public async Task<bool> Remove(UsuarioDTO userLogged, int id)
        {

            var entity = await _RecursoMaterialRespository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation, s => s.StockRecursoMaterial);

            bool servicioRecurso = await _servicioRecursoRepository.Any(s => s.Active && s.IdRecurso == entity.IdRecursoNavigation.Id);
            bool recursoAsignado = await _recursoAsignadoRepository.Any(s => s.Active && (s.IdRecurso2 == entity.IdRecursoNavigation.Id || s.IdRecurso1 == entity.IdRecursoNavigation.Id));

            if (!servicioRecurso && !recursoAsignado)
            {
                entity.IdRecursoNavigation.RemovalDate = DateTime.Now;
                entity.IdRecursoNavigation.Active = false;
                entity.IdRecursoNavigation.IdEstado = EstadosEnum.Dado_de_Baja.ToInt();
                entity.Active = false;
                await _RecursoMaterialRespository.Update(id, entity);

                foreach (var item in entity.StockRecursoMaterial)
                {
                    await _stockRecursoMaterialService.Remove((int)item.Id);
                }
                return true;
            }
            else
            {
                return false;
            }


        }

        public async Task<RecursoMaterialDTO> Update(UsuarioDTO userLogged, int id, RecursoMaterialDTO dto)
        {
            var entity = _mapper.Map<RecursoMaterial>(dto);
            var entityOG = await _RecursoMaterialRespository.GetBy(s => s.Id == entity.Id, s => s.IdRecursoNavigation);

            entity.IdRecursoNavigation = new Recurso();
            entity.IdRecursoNavigation.CreationDate = entityOG.IdRecursoNavigation.CreationDate;
            entity.IdRecursoNavigation.CreationUserId = entityOG.IdRecursoNavigation.CreationUserId;
            entity.IdRecursoNavigation.UpdateDate = DateTime.Now;
            entity.IdRecursoNavigation.UpdateUserId = userLogged.Id;
            entity.IdRecursoNavigation.Active = true;
            entity.IdRecursoNavigation.IdTipoRecurso = TipoRecursoEnum.Recurso_Material.ToInt();
            entity.IdTipoRecursoMaterial = dto.IdTipoRecursoMaterial;

            if ((bool)dto.Stockeable && entityOG.IdRecursoNavigation.IdEstado == EstadosEnum.Fuera_de_Servicio.ToInt())
            {
                await this.EndOutOfService(userLogged, entityOG.Id);
                entity.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
            }
            entity.Active = true;
            entity.Multiservicio = dto.Multiservicio;
            entity.Stockeable = dto.Stockeable;

            entity = await _RecursoMaterialRespository.Update(entity.Id, entity);

            return _mapper.Map<RecursoMaterialDTO>(entity);
        }

        public async Task<IEnumerable<RecursoMaterialDTO>> ListRecursosMaterialesAvailables(int idServicio, UsuarioDTO currUser)
        {
            // Lista donde van a estar los recursos materiales
            var result = new List<RecursoMaterialDTO>();

            //traigo los recursos que son multiservicio y los añado a la lista
            var recMultiservicio = await _RecursoMaterialRespository.ListBy(s => s.Active == true
            && !s.FueraServicio.Any(s=>s.Active == true)
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && !s.IdRecursoNavigation.ServicioRecurso.Any(x => x.IdServicio == idServicio && x.Active == true)
            && s.Multiservicio == true,
                x => x.IdRecursoNavigation, 
                x => x.FueraServicio,
                x => x.IdRecursoNavigation.ServicioRecurso);
            if (recMultiservicio.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(recMultiservicio));
            }

            //traigo los id de los recursos que ya estan en un servicio
            var rrMaterialServicio = _servicioRecursoRepository.ListBy(s => s.Active == true
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()
            && s.IdServicioNavigation.Active == true,
            s => s.IdRecursoNavigation,
            s => s.IdServicioNavigation).GetAwaiter().GetResult().Select(s => s.IdRecurso).ToList();

            //traigo los id de los recursos que fueron asignados a otro recurso
            var rrMaterialAsignado = _recursoAsignadoRepository.ListBy(s => s.Active == true
            && s.IdRecurso1Navigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecurso1Navigation.Active == true
            && s.IdRecurso2Navigation.Active == true
            && s.IdRecurso2Navigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt(),
            s => s.IdRecurso1Navigation,
            s => s.IdRecurso2Navigation).GetAwaiter().GetResult().Select(s => s.IdRecurso2Navigation.Id).ToList();

            // traigo los recursos materiales que no son stockeables y que no estan ni asignados a otro recurso ni a un servicio
            var rrNoStockeable = await _RecursoMaterialRespository.ListBy(s => s.Active == true
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && !s.FueraServicio.Any(s => s.Active == true)
            && s.Stockeable == false
            && s.Multiservicio == false
            && !rrMaterialServicio.Contains(s.IdRecurso) && !rrMaterialAsignado.Contains(s.IdRecurso),
            s => s.IdRecursoNavigation, s => s.FueraServicio);

            if (rrNoStockeable.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(rrNoStockeable));
            }

            //traigo los recursos materiales stockeables y los añado a la lista
            var rrStockeable = _stockRecursoMaterialRepository.ListBy(s => s.Active == true
            && s.IdEmpresa == currUser.IdEmpresa
            && s.CantidadDisponible.HasValue && s.CantidadDisponible > 0,
            s => s.IdUbicacionNavigation,
            s => s.IdUbicacionNavigation.Provincia,
            s => s.IdRecursoMaterialNavigation,
            s => s.IdRecursoMaterialNavigation.IdRecursoNavigation).GetAwaiter().GetResult().Select(s =>
            new RecursoMaterialDTO
            {
                Stockeable = s.IdRecursoMaterialNavigation.Stockeable,
                IdRecursoNavigation = new RecursoDTO
                {
                    Descripcion = "-" + s.IdUbicacionNavigation.Provincia.Nombre + ", " + s.IdUbicacionNavigation.Referencia,
                    Id = s.IdRecursoMaterialNavigation.IdRecurso,
                    IdUbicacion = s.IdUbicacion
                },
                Marca = s.IdRecursoMaterialNavigation.Marca,
                Modelo = s.IdRecursoMaterialNavigation.Modelo,
                Id = s.IdRecursoMaterial,
                IdRecurso = s.IdRecursoMaterialNavigation.IdRecurso,
                IdUbicacion = s.IdUbicacion
            }).ToList();
            if (rrStockeable.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(rrStockeable));
            }

            //devuelvo la lista ordenada por marca y modelo
            return result.OrderBy(s => s.Marca).ThenBy(s => s.Modelo);
        }

        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            bool mia = await _RecursoMaterialRespository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.Marca == name | s.Modelo == name) &&
                s.IdRecursoNavigation.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            );
            return mia;
        }

        public async Task<bool> StartOutOfService(UsuarioDTO loggedUser, int id)
        {
            var entity = await _RecursoMaterialRespository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation, s => s.FueraServicio);

            entity.IdRecursoNavigation.IdEstado = EstadosEnum.Fuera_de_Servicio.ToInt();

            entity.FueraServicio.Add(new FueraServicio
            {
                FechaInicio = DateTime.Now,
                CreationDate = DateTime.Now,
                CreationUserId = loggedUser.Id,
                Active = true,

            });

            await _RecursoMaterialRespository.Update(entity);

            return true;



        }

        public async Task<bool> EndOutOfService(UsuarioDTO loggedUser, int id)
        {
            var entity = await _RecursoMaterialRespository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation, s => s.FueraServicio);

            if (await _recursoAsignadoRepository.Any(s=> s.IdRecurso2 == entity.IdRecurso && s.Active == true))
            {
                entity.IdRecursoNavigation.IdEstado = EstadosEnum.Asignado.ToInt();
            }
            else
            {
                entity.IdRecursoNavigation.IdEstado = EstadosEnum.Disponible.ToInt();
            }
           

            if (entity.FueraServicio.LastOrDefault().Active == true)
            {
                entity.FueraServicio.LastOrDefault().FechaFin = DateTime.Now;
                entity.FueraServicio.LastOrDefault().UpdateDate = DateTime.Now;
                entity.FueraServicio.LastOrDefault().UpdateUserId = loggedUser.Id;
                entity.FueraServicio.LastOrDefault().Active = false;

                await _RecursoMaterialRespository.Update(entity);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<RecursoMaterialDTO>> ListRRMMFromRecurso(int idRecurso1, UsuarioDTO currUser)
        {
            // Lista donde van a estar los recursos materiales
            var result = new List<RecursoMaterialDTO>();

            //traigo los recursos que son multiservicio y los añado a la lista
            var recMultiservicio = await _RecursoMaterialRespository.ListBy(s =>
                s.IdRecursoNavigation.Active == true
                && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
                && s.IdRecursoNavigation.Id != idRecurso1
                && s.Multiservicio == true,
                x => x.IdRecursoNavigation,
                x=> x.IdTipoRecursoMaterialNavigation
            );
            if (recMultiservicio.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(recMultiservicio));
            }

            //traigo los id de los recursos que ya estan en un servicio
            var rrMaterialServicio = _servicioRecursoRepository.ListBy(s => s.Active == true
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt()
            && s.IdServicioNavigation.Active == true,
            s => s.IdRecursoNavigation,
            s => s.IdServicioNavigation).GetAwaiter().GetResult().Select(s => s.IdRecurso).ToList();

            //traigo los id de los recursos que fueron asignados a otro recurso
            var rrMaterialAsignado = _recursoAsignadoRepository.ListBy(s => s.Active == true
            && s.IdRecurso1Navigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecurso1Navigation.Active == true
            && s.IdRecurso2Navigation.Active == true
            && s.IdRecurso2Navigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Material.ToInt(),
            s => s.IdRecurso1Navigation,
            s => s.IdRecurso2Navigation).GetAwaiter().GetResult().Select(s => s.IdRecurso2Navigation.Id).ToList();

            // traigo los recursos materiales que no son stockeables y que no estan ni asignados a otro recurso ni a un servicio
            var rrNoStockeable = await _RecursoMaterialRespository.ListBy(s => s.Active == true
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
            && s.Stockeable == false
            && s.Multiservicio == false
            && s.IdRecursoNavigation.Id != idRecurso1
            && !rrMaterialServicio.Contains(s.IdRecurso) && !rrMaterialAsignado.Contains(s.IdRecurso),
            s=> s.IdTipoRecursoMaterialNavigation,
            s => s.IdRecursoNavigation);

            if (rrNoStockeable.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(rrNoStockeable));
            }

            //traigo los recursos materiales stockeables y los añado a la lista
            var rrStockeable = _stockRecursoMaterialRepository.ListBy(s => s.Active == true
            && s.IdEmpresa == currUser.IdEmpresa
            && s.CantidadDisponible.HasValue && s.CantidadDisponible > 0,
            s => s.IdUbicacionNavigation,
            s => s.IdUbicacionNavigation.Provincia,
            s => s.IdRecursoMaterialNavigation.IdTipoRecursoMaterialNavigation,
            s => s.IdRecursoMaterialNavigation,
            s => s.IdRecursoMaterialNavigation.IdRecursoNavigation).GetAwaiter().GetResult().Select( s =>
            new RecursoMaterialDTO
            {
                Stockeable = s.IdRecursoMaterialNavigation.Stockeable,
                IdRecursoNavigation = new RecursoDTO
                {
                    Descripcion = " - " + s.IdUbicacionNavigation.Provincia.Nombre + ", " + s.IdUbicacionNavigation.Referencia,
                    Id = s.IdRecursoMaterialNavigation.IdRecurso,
                    IdUbicacion = s.IdUbicacion,
                },
                Marca = s.IdRecursoMaterialNavigation.Marca,
                Modelo = s.IdRecursoMaterialNavigation.Modelo,
                Id = s.IdRecursoMaterial,
                IdRecurso = s.IdRecursoMaterialNavigation.IdRecurso,
                IdUbicacion = s.IdUbicacion,
                IdTipoRecursoMaterialNavigation = _mapper.Map<TipoRecursoMaterialDTO>(s.IdRecursoMaterialNavigation.IdTipoRecursoMaterialNavigation)
            }).ToList();
            if (rrStockeable.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoMaterialDTO>>(rrStockeable));
            }

            //devuelvo la lista ordenada por marca y modelo
            return result.OrderBy(s => s.Marca).ThenBy(s => s.Modelo);
        }
    }
}
