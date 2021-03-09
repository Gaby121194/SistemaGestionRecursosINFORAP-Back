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
using System.Web.Http.Results;

namespace INFORAP.API.Domain.Services
{

    public class RecursoHumanoService : IRecursoHumanoService
    {

        private readonly IBaseRepository<RecursoHumano> _recursoHumanoRepository;
        private readonly IRecursoService _recursoService;



        private readonly IBaseRepository<RecursoAsignado> _recursoAsignadoRepository;
        private readonly IBaseRepository<ServicioRecurso> _servicioRecursoRepository;

        private readonly IMapper _mapper;

        public RecursoHumanoService(IBaseRepository<RecursoHumano> recursoHumanoRepository, IBaseRepository<RecursoAsignado> recursoAsignadoRepository, IBaseRepository<ServicioRecurso> servicioRecursoRepository, IRecursoService recursoService
, IMapper mapper)
        {
            _recursoHumanoRepository = recursoHumanoRepository;
            _recursoAsignadoRepository = recursoAsignadoRepository;
            _servicioRecursoRepository = servicioRecursoRepository;
            _recursoService = recursoService;

            _mapper = mapper;
        }

        public async Task<RecursoHumanoDTO> Create(UsuarioDTO userLogged, RecursoHumanoDTO dto)
        {
            RecursoDTO recurso = new RecursoDTO
            {
                Descripcion = "rrhh",
                IdEmpresa = dto.IdEmpresa,
                CreationUserId = userLogged.Id,
                IdTipoRecurso = TipoRecursoEnum.Recurso_Humano.ToInt()
            };

            recurso = await _recursoService.Create(recurso);

            var entity = _mapper.Map<RecursoHumano>(dto);
            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;
            entity.IdEmpresa = userLogged.IdEmpresa;
            entity.IdRecurso = (int)recurso.Id;
            entity = await _recursoHumanoRepository.Insert(entity);
            dto = _mapper.Map<RecursoHumanoDTO>(entity);


            return dto;
        }

        public async Task<RecursoHumanoDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _recursoHumanoRepository.GetById(id);

            //Que solo devuelva la entidad si la persona pertenece a esa empresa o es super usuario
            if (userLogged.IdEmpresa == entity.IdEmpresa)
            {
                var dto = _mapper.Map<RecursoHumanoDTO>(entity);
                return dto;
            }
            return null;
        }
        public async Task<IEnumerable<RecursoHumanoDTO>> List(RecursoHumanoFilterDTO filter = null)
        {
            IEnumerable<RecursoHumano> entities;

            entities = await _recursoHumanoRepository.ListBy(recursohumano =>
                    (
                        (!filter.IdEmpresa.HasValue || recursohumano.IdEmpresa == filter.IdEmpresa.Value) &&
                        (!filter.CreationDateFrom.HasValue || recursohumano.CreationDate >= filter.CreationDateFrom.Value) &&
                        (!filter.CreationDateTo.HasValue || recursohumano.CreationDate <= filter.CreationDateTo.Value) &&
                        (filter.Nombre.IsNullOrEmpty() ||

                        recursohumano.Nombre.ToLower().Contains(filter.Nombre) ||
                        recursohumano.Cuil.ToLower().Contains(filter.Nombre) ||
                        recursohumano.Direccion.ToLower().Contains(filter.Nombre) ||
                        recursohumano.Email.ToLower().Contains(filter.Nombre) ||
                        recursohumano.Telefono.ToLower().Contains(filter.Nombre) ||
                        recursohumano.Apellido.ToLower().Contains(filter.Nombre) ||
                        // recursohumano.Multiservicio.Contains(filter.Nombre) ||
                        recursohumano.FechaNacimiento.ToString().Contains(filter.Nombre) ||
                        recursohumano.NroLegajo.ToLower().Contains(filter.Nombre))


                    ) &&

                    recursohumano.Active == true
            );

            var dtos = _mapper.Map<IEnumerable<RecursoHumanoDTO>>(entities);
            return dtos;
        }

        public async Task<bool> Remove(UsuarioDTO loggedUser, int id)
        {
            var entity = await _recursoHumanoRepository.GetBy(s => s.Id == id, s => s.IdRecursoNavigation);

            bool servicioRecurso = await _servicioRecursoRepository.Any(s => s.Active && s.IdRecurso == entity.IdRecursoNavigation.Id);
            bool recursoAsignado = await _recursoAsignadoRepository.Any(s => s.Active && (s.IdRecurso2 == entity.IdRecursoNavigation.Id || s.IdRecurso1 == entity.IdRecursoNavigation.Id));

            if (entity.IdEmpresa == loggedUser.IdEmpresa && !servicioRecurso && !recursoAsignado)
            {
                entity.Active = false;
                entity.IdRecursoNavigation.Active = false;
                entity.IdRecursoNavigation.RemovalDate = DateTime.Now;
                entity.RemovalDate = DateTime.Now;
                entity.UpdateUserId = loggedUser.Id;
                await _recursoHumanoRepository.Update(id, entity);

                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<RecursoHumanoDTO> Update(UsuarioDTO loggedUser, int id, RecursoHumanoDTO dto)
        {
            var entity = _mapper.Map<RecursoHumano>(dto);

            if (entity.IdEmpresa == loggedUser.IdEmpresa)
            {

                entity.UpdateDate = DateTime.Now;
                entity.UpdateUserId = loggedUser.Id;
                var original = await _recursoHumanoRepository.GetById(id);
                entity.CreationDate = original.CreationDate;
                entity.CreationUserId = original.CreationUserId;
                entity.Active = original.Active;
                try
                {
                    entity = await _recursoHumanoRepository.Update(id, entity);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return _mapper.Map<RecursoHumanoDTO>(entity);
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Exists(string value, int idEmpresa, int? id = null)
        {
            return await _recursoHumanoRepository.Any(s =>
                (id == null || s.Id != id.Value) &&
                ((s.NroLegajo == value) |
                (s.Cuil == value) |
                (s.Email == value)) &&
                s.Active == true &&
                s.IdEmpresa == idEmpresa //con esto me aseguro de que me busque de esta empresa la existencia, se lo paso desde el controller
            );
        }



        public async Task<IEnumerable<RecursoHumanoDTO>> ListFromService(int IdServicio, UsuarioDTO currUser)
        {
            var entities = await _servicioRecursoRepository.ListBy(s =>
            s.Active == true && s.IdServicio == IdServicio
            && s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
            && s.IdRecursoNavigation.RecursoHumano != null
            && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa,
            s => s.IdRecursoNavigation,
            s => s.IdRecursoNavigation.RecursoHumano);

            return _mapper.Map<IEnumerable<RecursoHumanoDTO>>(entities.Select(s => s.IdRecursoNavigation.RecursoHumano).ToList());
        }

        public async Task<IEnumerable<RecursoHumanoDTO>> ListRecursosHumanosAvailables(UsuarioDTO currUser, int? idServicio = null)
        {
            var result = new List<RecursoHumanoDTO>();
            var recIds = _servicioRecursoRepository.ListBy(s => s.IdRecursoNavigation.IdTipoRecurso == TipoRecursoEnum.Recurso_Humano.ToInt()
             && s.IdRecursoNavigation.IdEmpresa == currUser.IdEmpresa
             && s.IdServicioNavigation.Active == true && s.Active == true,
             x => x.IdRecursoNavigation,
             x => x.IdServicioNavigation)
                .GetAwaiter().GetResult().Select(s => s.IdRecurso).ToList();
            var rrhhMulti = await _recursoHumanoRepository.ListBy(s => s.Active && s.IdEmpresa == currUser.IdEmpresa && s.Multiservicio == true
            && (idServicio == null || (!s.ServicioIdRecursoHumano1Navigation.Any(t => t.Active && t.Id == idServicio.Value)
            && !s.IdRecursoNavigation.ServicioRecurso.Any(k => k.Active == true && k.IdServicio == idServicio.Value)))
            , s => s.IdRecursoNavigation
            , s => s.IdRecursoNavigation.ServicioRecurso
            , s => s.ServicioIdRecursoHumano1Navigation
            );
            if (rrhhMulti.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoHumanoDTO>>(rrhhMulti));
            }
            var rrHhNoMulti = await _recursoHumanoRepository.ListBy(s => s.Active && s.IdEmpresa == currUser.IdEmpresa
             && s.Multiservicio != true && !recIds.Contains(s.IdRecurso) && !s.ServicioIdRecursoHumano1Navigation.Any(p => p.Active == true)
             , s => s.IdRecursoNavigation
             , s => s.ServicioIdRecursoHumano1Navigation);
            if (rrHhNoMulti.Any())
            {
                result.AddRange(_mapper.Map<IEnumerable<RecursoHumanoDTO>>(rrHhNoMulti));
            }
            return result;
        }
        public async Task<IEnumerable<RecursoHumanoDTO>> ListRecursosHumanosWithOutUser(UsuarioDTO currUser, int? idRecursoHumano = null)
        {
            var entities = await _recursoHumanoRepository.ListBy(s => !s.Usuario.Any(s=>s.Active == true) 
            && s.IdEmpresa == currUser.IdEmpresa);
            var result = new List<RecursoHumanoDTO>();
            if (idRecursoHumano.HasValue)
            {
                var rrhhDto = _mapper.Map<RecursoHumanoDTO>(await _recursoHumanoRepository.GetBy(s => s.Id == idRecursoHumano.Value && s.IdEmpresa == currUser.IdEmpresa && s.Active == true));
                result.Add(rrhhDto);
            }
            result.AddRange(_mapper.Map<IEnumerable<RecursoHumanoDTO>>(entities));
            return result;
        }
        /*  public async Task<IEnumerable<RecursoHumanoDTO>> Initialize(UsuarioDTO user)
           {
               var index = 1;
               var result = new List<RecursoHumanoDTO>();
               var entities = new List<RecursoHumano> { new RecursoHumano
               {
                   Active = true,Apellido = "Ruggeri",CreationDate = DateTime.Now,CreationUserId = user.Id,Direccion = "Falsa 123",Cuil ="20367680552",Email = $"email_{index++}@ii.com",FechaNacimiento = new DateTime(1991,11,20),IdEmpresa = user.IdEmpresa,Multiservicio =false,Nombre = "David",NroLegajo = "701", Telefono = "2613079079",
                   IdRecursoNavigation = new Recurso { Descripcion = "rrhh",Active = true ,IdEmpresa = user.IdEmpresa,IdTipoRecurso = 1,FechaAlta = DateTime.Now,CreationDate = DateTime.Now,CreationUserId = user.Id }  
               },
               new RecursoHumano
               {
                   Active = true,Apellido = "Díaz",CreationDate = DateTime.Now,CreationUserId = user.Id,Direccion = "Falsa 123",Cuil ="20367680542",Email = $"email_{index++}@ii.com",FechaNacimiento = new DateTime(1991,11,20),IdEmpresa = user.IdEmpresa,Multiservicio =false,Nombre = "Germán",NroLegajo = "702", Telefono = "2613079079",
                   IdRecursoNavigation = new Recurso { Descripcion = "rrhh",Active = true ,IdEmpresa = user.IdEmpresa,IdTipoRecurso = 1,FechaAlta = DateTime.Now,CreationDate = DateTime.Now,CreationUserId = user.Id }
               },
               new RecursoHumano
               {
                   Active = true,Apellido = "Lopez",CreationDate = DateTime.Now,CreationUserId = user.Id,Direccion = "Falsa 123",Cuil ="20367680532",Email = $"email_{index++}@ii.com",FechaNacimiento = new DateTime(1991,11,20),IdEmpresa = user.IdEmpresa,Multiservicio =false,Nombre = "Jonatan",NroLegajo = "703", Telefono = "2613079079",
                   IdRecursoNavigation = new Recurso { Descripcion = "rrhh",Active = true ,IdEmpresa = user.IdEmpresa,IdTipoRecurso = 1,FechaAlta = DateTime.Now,CreationDate = DateTime.Now,CreationUserId = user.Id }
               }};
               foreach (var item in entities)
               {
                   var dto = _mapper.Map<RecursoHumanoDTO>(await this._recursoHumanoRepository.Insert(item));
                   result.Add(dto);
               }
               return result;

           }*/
    }
}
