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
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class TipoRecursoMaterialService : ITipoRecursoMaterialService
    {
        private readonly IBaseRepository<TipoRecursoMaterial> _tipoRecursoMaterialRespository;

        private readonly IMapper _mapper;
        private readonly IBaseRepository<RecursoMaterial> _recursoMaterialRepository;

        public TipoRecursoMaterialService(IBaseRepository<TipoRecursoMaterial> tipoRecursoMaterialRespository, IBaseRepository<RecursoMaterial> recursoMaterialRepository, IMapper mapper)
        {
            _tipoRecursoMaterialRespository = tipoRecursoMaterialRespository;
            _mapper = mapper;
            _recursoMaterialRepository = recursoMaterialRepository;
        }

        public async Task<TipoRecursoMaterialDTO> Create(UsuarioDTO userLogged, TipoRecursoMaterialDTO dto)
        {
            var entities = _mapper.Map<TipoRecursoMaterial>(dto);
            entities.Active = true;
            entities.CreationDate = DateTime.Now;
            entities.UpdateDate = DateTime.Now;
            entities.CreationUserId = userLogged.Id;
            entities.UpdateUserId = userLogged.Id;
            entities.IdEmpresa = userLogged.IdEmpresa;
            entities = await _tipoRecursoMaterialRespository.Insert(entities);
            return _mapper.Map<TipoRecursoMaterialDTO>(entities);
        }

        public async Task<TipoRecursoMaterialDTO> GetById(UsuarioDTO userLogged,int id)
        {
            var entity = await _tipoRecursoMaterialRespository.GetById(id);
            return _mapper.Map<TipoRecursoMaterialDTO>(entity);
        }

        public async Task<IEnumerable<TipoRecursoMaterialDTO>> List(UsuarioDTO userlogged, TipoRecursoMaterialFilterDTO filter = null/*, bool? includeRrhh = false*/)
        {

            var entities = await _tipoRecursoMaterialRespository.ListBy(tipo =>
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


            return _mapper.Map<IEnumerable<TipoRecursoMaterialDTO>>(entities);



/*            if (!includeRrhh == true)
            {
                var entities = await _tipoRecursoMaterialRespository.ListBy();
                var dtos = _mapper.Map<IEnumerable<TipoRecursoMaterialDTO>>(entities);
                return dtos;
            }
            else
            {
                var entities = await _tipoRecursoMaterialRespository.ListBy();
                var dtos = _mapper.Map<IEnumerable<TipoRecursoMaterialDTO>>(entities);
                var result = new List<TipoRecursoMaterialDTO> { new TipoRecursoMaterialDTO
                {
                    Active = true,
                    Descripcion = TipoRecursoEnum.Recurso_Humano.GetDescription(),
                    Id = TipoRecursoEnum.Recurso_Humano.ToInt()
                } };
                result.AddRange(dtos);
                return result;
            }*/

        }
        public async Task<bool> Remove(UsuarioDTO loggedUser, int id)
        {

            var entity = await _tipoRecursoMaterialRespository.GetById(id);

            if (!await _recursoMaterialRepository.Any(s=> s.IdTipoRecursoMaterial == id)){
                entity.RemovalDate = DateTime.Now;
                entity.Active = false;
                await _tipoRecursoMaterialRespository.Update(id, entity);
                return true;
            }
            else
            {
                return false;
            }

   
        }

        public async Task<TipoRecursoMaterialDTO> Update(UsuarioDTO loggedUser, int id, TipoRecursoMaterialDTO dto)
        {

            var entity = _mapper.Map<TipoRecursoMaterial>(dto);

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = loggedUser.Id;
            entity.Active = true;
            entity.IdEmpresa = loggedUser.IdEmpresa;

            entity.CreationDate = (await _tipoRecursoMaterialRespository.GetById(id)).CreationDate;
            entity.CreationUserId = (await _tipoRecursoMaterialRespository.GetById(id)).CreationUserId;

            entity = await _tipoRecursoMaterialRespository.Update(id, entity);

            return _mapper.Map<TipoRecursoMaterialDTO>(entity);

        }


        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _tipoRecursoMaterialRespository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.Descripcion == name.Trim() &&
                   s.IdEmpresa == userLogged.IdEmpresa &&
                s.Active == true
            ));
        }
    }
}
