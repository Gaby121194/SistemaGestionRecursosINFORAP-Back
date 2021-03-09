using AutoMapper;
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
    public class TipoRecursoRenovableService : ITipoRecursoRenovableService
    {
        private readonly IBaseRepository<TipoRecursoRenovable> _tipoRecursoRenovableRespository;
        private readonly IBaseRepository<RecursoRenovable> _recursoRenovableRepository;
        private readonly IMapper _mapper;

        public TipoRecursoRenovableService(IBaseRepository<TipoRecursoRenovable> tipoRecursoRenovableRespository,
            IBaseRepository<RecursoRenovable> recursoRenovableRepository,
            IMapper mapper)
        {
            _tipoRecursoRenovableRespository = tipoRecursoRenovableRespository;
            _recursoRenovableRepository = recursoRenovableRepository;
            _mapper = mapper;
        }

        public async Task<TipoRecursoRenovableDTO> Create(UsuarioDTO userLogged, TipoRecursoRenovableDTO dto)
        {
            var entities = _mapper.Map<TipoRecursoRenovable>(dto);
            entities.Active = true;
            entities.CreationDate = DateTime.Now;
            entities.UpdateDate = DateTime.Now;
            entities.CreationUserId = userLogged.Id;
            entities.UpdateUserId = userLogged.Id;
            entities.IdEmpresa = userLogged.IdEmpresa;
            entities = await _tipoRecursoRenovableRespository.Insert(entities);
            return _mapper.Map<TipoRecursoRenovableDTO>(entities);
        }

        public async Task<TipoRecursoRenovableDTO> GetById(UsuarioDTO userLogged, int id)
        {
            var entity = await _tipoRecursoRenovableRespository.GetById(id);
            return _mapper.Map<TipoRecursoRenovableDTO>(entity);
        }
        public async Task<IEnumerable<TipoRecursoRenovableDTO>> List(UsuarioDTO userlogged, TipoRecursoRenovableFilterDTO filter = null)
        {

            var entities = await _tipoRecursoRenovableRespository.ListBy(tipo =>
                           (
                               (tipo.IdEmpresa == userlogged.IdEmpresa) &&
                               (!filter.CreationDateFrom.HasValue || tipo.CreationDate >= filter.CreationDateFrom.Value) &&
                               (!filter.CreationDateTo.HasValue || tipo.CreationDate <= filter.CreationDateTo.Value) &&

                               (
                                   filter.Name.IsNullOrEmpty() ||
                                   tipo.Descripcion.ToLower().Contains(filter.Name)
                               )
                           ) &&
                       tipo.Active == true
                       );


            return _mapper.Map<IEnumerable<TipoRecursoRenovableDTO>>(entities);




        }
        public async Task<bool> Remove(UsuarioDTO loggedUser, int id)
        {
            var entity = await _tipoRecursoRenovableRespository.GetById(id);
            var recursoReno = await _recursoRenovableRepository.Any(s => s.IdTipoRecursoRenovable == id);

            if (!recursoReno)
            {
                entity.RemovalDate = DateTime.Now;
                entity.Active = false;
                await _tipoRecursoRenovableRespository.Update(id, entity);
                return true;
            }
            else
            {
                return false;
            }
            


        }

        public async Task<IEnumerable<RolDTO>> ListByEmpresaId(int id)
        {
            var entity = await _tipoRecursoRenovableRespository.ListBy(null);
            var dtos = _mapper.Map<IEnumerable<RolDTO>>(entity);
            return dtos;
        }


        public async Task<TipoRecursoRenovableDTO> Update(UsuarioDTO loggedUser, int id, TipoRecursoRenovableDTO dto)
        {

            var entity = _mapper.Map<TipoRecursoRenovable>(dto);

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = loggedUser.Id;
            entity.Active = true;
            entity.IdEmpresa = loggedUser.IdEmpresa;

            entity.CreationDate = (await _tipoRecursoRenovableRespository.GetById(id)).CreationDate;
            entity.CreationUserId = (await _tipoRecursoRenovableRespository.GetById(id)).CreationUserId;

            entity = await _tipoRecursoRenovableRespository.Update(id, entity);

            return _mapper.Map<TipoRecursoRenovableDTO>(entity);

        }


        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _tipoRecursoRenovableRespository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.Descripcion == name.Trim() &&
                   s.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            ));
        }
    }
}