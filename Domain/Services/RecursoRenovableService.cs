using AutoMapper;
using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class RecursoRenovableService : IRecursoRenovableService
    {
        private readonly IBaseRepository<RecursoRenovable> _recursoRenovableRepository;
        private readonly IBaseRepository<Provincia> _provinciaRepository;
        private readonly IBaseRepository<Recurso> _recursoRepository;
        private readonly IBaseRepository<Estado> _estadoRepository;
        private readonly IBaseRepository<Ubicacion> _ubicacionRepository;
        private readonly IBaseRepository<TipoRecurso> _tipoRecursoRepository;
        private readonly IBaseRepository<TipoRecursoRenovable> _tipoRecursoRenovableRepository;
        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;

        private readonly IMapper _mapper;

        public RecursoRenovableService(IBaseRepository<RecursoRenovable> recursoRenovableRepository, IMapper mapper,
            IBaseRepository<Recurso> recursoRepository, IBaseRepository<Estado> estadoRepository,
            IBaseRepository<Ubicacion> ubicacionRepository, IBaseRepository<TipoRecurso> tipoRecursoRepository,
            IBaseRepository<TipoRecursoRenovable> tipoRecursoRenovableRepository,
            IBaseRepository<RecursoAsignado> recursoAsignadoRepository,
            IBaseRepository<Provincia> provinciaRepository,
            IBaseRepository<ServicioRecurso> servicioRecursoRepository)


        {
            _recursoRenovableRepository = recursoRenovableRepository;
            _provinciaRepository = provinciaRepository;
            _recursoRepository = recursoRepository;
            _estadoRepository = estadoRepository;
            _ubicacionRepository = ubicacionRepository;
            _tipoRecursoRenovableRepository = tipoRecursoRenovableRepository;
            _tipoRecursoRepository = tipoRecursoRepository;
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;

            _mapper = mapper;
        }
        public async Task<RecursoRenovableDTO> Create(RecursoRenovableDTO dto, UsuarioDTO usuario)
        {
            var entity = _mapper.Map<RecursoRenovable>(dto);
            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.CreationUserId = usuario.Id;
            entity.UpdateUserId = usuario.Id;



            Recurso entityRecurso = new Recurso
            {
                IdEstado = EstadosEnum.Disponible.ToInt(),
                IdTipoRecurso = TipoRecursoEnum.Recurso_Renovable.ToInt(),
                IdUbicacion = dto.IdUbicacion,
                Active = true,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreationUserId = usuario.Id,
                UpdateUserId = usuario.Id,
                Descripcion = dto.Descripcion,
                IdEmpresa = usuario.IdEmpresa
            };

            entity.IdRecursoNavigation = entityRecurso;

            var entidad = await _recursoRepository.Insert(entityRecurso);

            entity.IdRecurso = entidad.Id;



            entity = await _recursoRenovableRepository.Insert(entity);



            return _mapper.Map<RecursoRenovableDTO>(entity);



        }

        public async Task<RecursoRenovableDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _recursoRenovableRepository.GetBy
                (
                    s => s.Id == id,
                    s => s.IdRecursoNavigation.IdEstadoNavigation,
                    s => s.IdTipoRecursoRenovableNavigation
                );

            return _mapper.Map<RecursoRenovableDTO>(entity);
        }

        public async Task<IEnumerable<RecursoRenovableDTO>> List(UsuarioDTO userlogged, RecursosRenovablesFilterDTO filter = null)
        {
            var entities = await _recursoRenovableRepository.ListBy(recursoMaterial =>
                (
                    (recursoMaterial.IdRecursoNavigation.IdEmpresa == userlogged.IdEmpresa) &&
                    (!filter.CreationDateFrom.HasValue || recursoMaterial.IdRecursoNavigation.CreationDate >= filter.CreationDateFrom.Value) &&
                    (!filter.CreationDateTo.HasValue || recursoMaterial.IdRecursoNavigation.CreationDate <= filter.CreationDateTo.Value) &&
                    (filter.IdEstado.IsNullOrEmpty() || recursoMaterial.IdRecursoNavigation.IdEstado.ToString() == filter.IdEstado) &&
                    (
                        filter.Name.IsNullOrEmpty() ||
                        recursoMaterial.IdTipoRecursoRenovableNavigation.Descripcion.ToLower().Contains(filter.Name) ||
                        recursoMaterial.IdRecursoNavigation.Descripcion.ToLower().Contains(filter.Name) ||
                        recursoMaterial.IdRecursoNavigation.IdEstadoNavigation.Descripcion.ToLower().Contains(filter.Name)

                    )
                ) &&
            recursoMaterial.IdRecursoNavigation.Active == true,
            s => s.IdRecursoNavigation.IdEstadoNavigation,
            s => s.IdRecursoNavigation.IdUbicacionNavigation,
            s => s.IdTipoRecursoRenovableNavigation

            );
            var dtos = _mapper.Map<IEnumerable<RecursoRenovableDTO>>(entities);
            return dtos;



        }

        public async Task Remove(UsuarioDTO userLogged, int id)
        {
            var entity = await _recursoRenovableRepository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation);

            var recursoAsignado = await _recursoAsignadoRepository.ListBy(s => s.Active && (s.IdRecurso2 == entity.IdRecursoNavigation.Id || s.IdRecurso1 == entity.IdRecursoNavigation.Id),
                     s => s.IdRecurso1Navigation, s => s.IdRecurso1Navigation.RecursoHumano, s => s.IdRecurso1Navigation.RecursoMaterial);

            if (!recursoAsignado.Any())
            {
                entity.IdRecursoNavigation.RemovalDate = DateTime.Now;
                entity.IdRecursoNavigation.Active = false;
                entity.IdRecursoNavigation.IdEstado = EstadosEnum.Dado_de_Baja.ToInt();
                entity.Active = false;
                entity.RemovalDate = DateTime.Now;
                await _recursoRenovableRepository.Update(id, entity);
            }
            else
            {
                var mensaje = "";
                foreach (var item in recursoAsignado)
                {
                    if (item.IdRecurso1Navigation.RecursoMaterial.Any())
                    {
                        mensaje += item.IdRecurso1Navigation.RecursoMaterial.FirstOrDefault().Marca + ", " + item.IdRecurso1Navigation.RecursoMaterial.FirstOrDefault().Modelo + Environment.NewLine;
                    }
                    else
                    {
                        mensaje += item.IdRecurso1Navigation.RecursoHumano.FirstOrDefault().Apellido + ", " + item.IdRecurso1Navigation.RecursoHumano.FirstOrDefault().Nombre + Environment.NewLine;
                    }
                }
                throw new BadRequestException(mensaje);
            }

        }

        public async Task<RecursoRenovableDTO> Update(UsuarioDTO userLogged, int id, RecursoRenovableDTO dto)
        {
            var entity = _mapper.Map<RecursoRenovable>(dto);
            var entityOG = await _recursoRenovableRepository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation);
            var recursoOG = await _recursoRepository.GetBy(s => s.Id == entityOG.IdRecurso);

            //modificamos el recurso
            recursoOG.IdEstado = EstadosEnum.Disponible.ToInt();
            recursoOG.IdUbicacion = dto.IdUbicacion;
            recursoOG.Descripcion = dto.Descripcion;




            //modificamos el recurso renovable
            entity.IdRecursoNavigation = recursoOG;
            entity.CreationDate = entityOG.CreationDate;
            entity.UpdateDate = DateTime.Now;
            entity.CreationUserId = entityOG.CreationUserId;
            entity.UpdateUserId = userLogged.Id;
            entity.Active = true;

            //se guarda el recurso modificado
            await _recursoRepository.Update(recursoOG.Id, recursoOG);

            //se guarda el recurso renovable modificado
            entity = await _recursoRenovableRepository.Update(entity.Id, entity);

            return _mapper.Map<RecursoRenovableDTO>(entity); ;

        }

        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            bool mia = await _recursoRenovableRepository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.IdRecursoNavigation.Descripcion == name) &&
                s.IdRecursoNavigation.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            );
            return mia;
        }

        public async Task<IEnumerable<RecursoRenovableDTO>> ListRRRRFromRecurso(int idRecurso1, UsuarioDTO currUser)
        {
            // Lista donde van a estar los recursos materiales
            var result = new List<RecursoRenovableDTO>();

            //traigo los id de los recursos que fueron asignados a otro recurso
            var rrRenovableAsignados = _recursoAsignadoRepository.ListBy(s => s.Active == true
            && s.IdRecurso1Navigation.IdEmpresa == currUser.IdEmpresa
            && s.IdRecurso1Navigation.Active == true
            && s.IdRecurso2Navigation.Active == true
            && s.IdRecurso2Navigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Renovable.ToInt(),
            s => s.IdRecurso1Navigation,
            s => s.IdRecurso2Navigation.IdUbicacionNavigation).GetAwaiter().GetResult().Select(s => s.IdRecurso2Navigation.Id).ToList();

            // traigo los recursos renovables y pongo los que no estan asignados a otro recurso
            var rrNoAsignados = await _recursoRenovableRepository.ListBy(s => s.Active == true
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
/*            && s.FechaVencimiento >= DateTime.Now
*/            && s.IdRecursoNavigation.Id != idRecurso1
            && !rrRenovableAsignados.Contains(s.IdRecurso),
            s=> s.IdTipoRecursoRenovableNavigation,
            s => s.IdRecursoNavigation.IdUbicacionNavigation);

            if (rrNoAsignados.Any())
            {
                foreach (var item in rrNoAsignados)
                {
                    var temp = _mapper.Map<RecursoRenovableDTO>(item);
                    temp.IdRecursoNavigation.IdUbicacionNavigation.DescripcionProvincia = (await _provinciaRepository.GetBy(s => s.IdProvincia == temp.IdRecursoNavigation.IdUbicacionNavigation.IdProvincia)).Nombre;
                    result.Add(temp);
                }

            }



            //devuelvo la lista ordenada por marca y modelo
            return result.OrderBy(s => s.Descripcion);
        }
    }

}
