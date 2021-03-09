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
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public ClienteService(
            IBaseRepository<Cliente> clienteRepository,
            IMapper mapper


            )
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteDTO> Create(UsuarioDTO userLogged, ClienteDTO dto)
        {
            var entity = _mapper.Map<Cliente>(dto);
            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;
            entity.IdEmpresa = userLogged.IdEmpresa;

            entity = await _clienteRepository.Insert(entity);

            return _mapper.Map<ClienteDTO>(entity);
        }


        public async Task<ClienteDTO> GetById(UsuarioDTO userLogged,  int id)
        {
            var entity = await _clienteRepository.GetBy(s => s.Id == id, s => s.Empresa, s => s.Servicio);


            if (userLogged.IdEmpresa == entity.IdEmpresa )
            {
                var dto = _mapper.Map<ClienteDTO>(entity);
                return dto;
            }
            return null;
        }

        public async Task<IEnumerable<ClienteDTO>> List(UsuarioDTO userLogged, ClienteFilterDTO filter = null)
        {
            IEnumerable<Cliente> entities;

            entities = await _clienteRepository.ListBy(cliente =>
                (
                    (cliente.IdEmpresa == userLogged.IdEmpresa) &&
                    (!filter.CreationDateFrom.HasValue || cliente.CreationDate >= filter.CreationDateFrom.Value) &&
                    (!filter.CreationDateTo.HasValue || cliente.CreationDate <= filter.CreationDateTo.Value) &&

                    (
                        filter.Name.IsNullOrEmpty() ||
                        cliente.Cuil.ToLower().Contains(filter.Name) ||
                        cliente.RazonSocial.ToLower().Contains(filter.Name) ||
                        cliente.Telefono.ToLower().Contains(filter.Name) ||
                        cliente.Email.ToLower().Contains(filter.Name))
                    ) &&
                    cliente.Active == true,
                    s => s.Empresa,
                    s => s.Servicio
                );
            var dtos = _mapper.Map<IEnumerable<ClienteDTO>>(entities);
            return dtos;

        }

        public async Task<bool> Remove(UsuarioDTO loggedUser, int id)
        {
            var entity = await _clienteRepository.GetBy(s=> s.Id == id, s=> s.Servicio);
            if ((entity.IdEmpresa == loggedUser.IdEmpresa ) && !entity.Servicio.Any(s => s.Active))
            {
                entity.Active = false;
                entity.RemovalDate = DateTime.Now;
                entity.UpdateUserId = loggedUser.Id;
                await _clienteRepository.Update(id, entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ClienteDTO> Update(UsuarioDTO userLogged,  int id, ClienteDTO dto)
        {
            var entity = _mapper.Map<Cliente>(dto);

            if (entity.IdEmpresa == userLogged.IdEmpresa )
            {

                entity.UpdateDate = DateTime.Now;
                entity.UpdateUserId = userLogged.Id;
                var original = await _clienteRepository.GetById(id);
                entity.CreationDate = original.CreationDate;
                entity.CreationUserId = original.CreationUserId;
                entity.Active = original.Active;

                entity = await _clienteRepository.Update(id, entity);
                return _mapper.Map<ClienteDTO>(entity);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null)
        {
            return await _clienteRepository.Any(s =>
             (id == null || s.Id != id.Value) &&
             (s.RazonSocial == name.Trim() | s.Cuil == name.Trim()) &&
             s.IdEmpresa == userLogged.IdEmpresa &&
             s.Active == true
         );
        }

    }
}
