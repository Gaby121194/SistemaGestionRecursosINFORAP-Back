using AutoMapper;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class ControladorService : IControladorService
    {
        private readonly IBaseRepository<Controlador> _controladorRepository;
        private readonly IMapper _mapper;

        public ControladorService(IBaseRepository<Controlador> controladorRepository, IMapper mapper)
        {
            _controladorRepository = controladorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ControladorDTO>> List(ControladorFilterDTO filter,bool onlyActive = false)
        {
            var entities = await _controladorRepository.ListBy(s => (! onlyActive || s.Active == true)
            && (string.IsNullOrEmpty(filter.Nombre) || s.Display.Contains(filter.Nombre) || s.Url.Contains(filter.Nombre) || s.Icon.Contains(filter.Nombre))
            && (!filter.CreationDateFrom.HasValue || (filter.CreationDateFrom.Value <= s.CreationDate))
            && (!filter.CreationDateTo.HasValue || (filter.CreationDateTo.Value >= s.CreationDate))
            );
            return _mapper.Map<IEnumerable<ControladorDTO>>(entities);
        }

        public async Task<ControladorDTO> Insert(ControladorDTO dto, UsuarioDTO currUser)
        {
            var entity = _mapper.Map<Controlador>(dto);
            entity.UpdateDate = entity.CreationDate = DateTime.Now;
            entity.UpdateUserId = entity.CreationUserId = currUser.Id;
            entity.Active = true;
            entity = await _controladorRepository.Insert(entity);
            return _mapper.Map<ControladorDTO>(entity);
        }

        public async Task<ControladorDTO> Update(ControladorDTO dto, int id, UsuarioDTO currUser)
        {
            var entity = await _controladorRepository.GetBy(s => s.Id == id);
            if (entity == null) throw new NotFoundException();

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Display = dto.Display;
            entity.Url = dto.Url;
            entity.Icon = dto.Icon;
            entity.Show = dto.Show;
            entity = await _controladorRepository.Update(entity);
            return _mapper.Map<ControladorDTO>(entity);
        }
        public async Task<ControladorDTO> Disable(int id, UsuarioDTO currUser)
        {
            var entity = await _controladorRepository.GetBy(s => s.Id == id);
            if (entity == null) throw new NotFoundException();

            entity.UpdateDate = entity.RemovalDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Active = false;
            entity = await _controladorRepository.Update(entity);
            return _mapper.Map<ControladorDTO>(entity);
        }
        public async Task<ControladorDTO> Enable(int id, UsuarioDTO currUser)
        {
            var entity = await _controladorRepository.GetBy(s => s.Id == id && !s.Active);
            if (entity == null) throw new NotFoundException();
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = currUser.Id;
            entity.Active = true;
            entity = await _controladorRepository.Update(entity);
            return _mapper.Map<ControladorDTO>(entity);
        }
        public async Task<bool> ExistDisplay(string display, int? id = null)
        {
            return await _controladorRepository.Any(s => s.Active == true && s.Display == display && (id == null || s.Id != id));
        }
        public async Task<bool> ExistUrl(string url, int? id = null)
        {
            return await _controladorRepository.Any(s => s.Active == true && s.Url == url && (id == null || s.Id != id));
        }

        public async Task<ControladorDTO> GetBy(int id)
        {
            var entity = await _controladorRepository.GetBy(s => s.Id == id);
            if (entity == null) throw new NotFoundException();
            return _mapper.Map<ControladorDTO>(entity);
        }
    }
}
