using AutoMapper;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IBaseRepository<Empresa> _empresaRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;

        public EmpresaService
            (
                IBaseRepository<Empresa> empresaRepository,
                IRolService rolService,
                IUsuarioService userService,
                IMapper mapper
            )
            {
                _empresaRepository = empresaRepository;
                _usuarioService = userService;
                _rolService = rolService;
                _mapper = mapper;
            }

        public async Task<EmpresaDTO> Create(UsuarioDTO userLogged, EmpresaDTO dto)
        {
            //relleno el entity con los datos de la empresa
            var entity = _mapper.Map<Empresa>(dto);
            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.CreationUserId = userLogged.Id;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUserId = userLogged.Id;

            //creo la empresa
            entity = await _empresaRepository.Insert(entity);

            //genero un nuevo rol con permiso de manager
            int[] Permisos = { 2 };

            RolDTO rol = new RolDTO
            {
                Nombre = "Manager",
                Descripcion = "Administrador de la Empresa",
                Permisos = Permisos,
            };

            var userLoggedRol = userLogged;
            userLoggedRol.IdEmpresa = entity.Id;
            //creo el rol
            rol = await _rolService.Create(rol, userLoggedRol);

            //genero el usuario con los datos
            var usuarioDTO = new UsuarioDTO
            {
                Nombre = dto.NombreManager,
                Apellido = dto.ApellidoManager,
                Email = dto.EmailManager,
                IdRol = rol.Id,
                IdEmpresa = entity.Id
            };

            //creo el usuario
            await _usuarioService.Insert(userLogged, usuarioDTO);

            return _mapper.Map<EmpresaDTO>(entity);
        }

    

        public async Task<EmpresaDTO> GetById(UsuarioDTO userLogged, bool isSuperUser, int id)
        {

            var entity = await _empresaRepository.GetById(id);
            if (entity.Id == userLogged.IdEmpresa || isSuperUser)
            {
                var dto = _mapper.Map<EmpresaDTO>(entity);
                return dto;
            } else
            {
                return null;
            }


        }

        public async Task<IEnumerable<EmpresaDTO>> List(EmpresaFilterDTO filter = null)
        {
            IEnumerable<Empresa> entities;


            entities = await _empresaRepository.ListBy(empresa =>
                    (
                        (filter.IdEmpresa == null || empresa.Id == filter.IdEmpresa.Value) &&
                        (!filter.CreationDateFrom.HasValue || empresa.CreationDate >= filter.CreationDateFrom.Value) && 
                        (!filter.CreationDateTo.HasValue || empresa.CreationDate <= filter.CreationDateTo.Value) &&
                        (filter.Active == "null" || filter.Active.IsNullOrEmpty() || empresa.Active == Boolean.Parse(filter.Active)) &&

                        (filter.RazonSocial.IsNullOrEmpty() || empresa.RazonSocial.ToLower().Contains(filter.RazonSocial) ||
                        empresa.Cuit.ToLower().Contains(filter.RazonSocial) ||
                        empresa.Domicilio.ToLower().Contains(filter.RazonSocial) ||
                        empresa.CorreoContacto.ToLower().Contains(filter.RazonSocial))
                    )
            );

            var dtos = _mapper.Map<IEnumerable<EmpresaDTO>>(entities);
            return dtos;
        }

        public async Task Remove(int id)
        {
            var entity = await _empresaRepository.GetById(id);
            entity.Active = false;
            entity.RemovalDate = DateTime.Now;
            await _empresaRepository.Update(id, entity);
        }

        public async Task<EmpresaDTO> Update(UsuarioDTO loggedUser, int id, EmpresaDTO dto)
        {
            var entity = _mapper.Map<Empresa>(dto);
            entity.UpdateDate = DateTime.Now;
            entity.Active = true;
            entity.UpdateUserId = loggedUser.Id; 

            var entityOG = await _empresaRepository.GetById(id);

            entity.CreationDate = entityOG.CreationDate;
            entity.CreationUserId = entityOG.CreationUserId;


            entity = await _empresaRepository.Update(id, entity);
            return  _mapper.Map<EmpresaDTO>(entity);
        }

        public async Task<EmpresaDTO> Activate(int id)
        {
            var entity = await _empresaRepository.GetBy(s => s.Id == id);

            entity.Active = true;

            entity = await _empresaRepository.Update(id, entity);

            return _mapper.Map<EmpresaDTO>(entity);
        }


        public async Task<bool> Exists(string name, int? id =null)
        {

            return await _empresaRepository.Any(s =>
                (id == null || s.Id != id.Value) &&
                (s.Cuit == name.Trim() || s.RazonSocial == name.Trim() || s.CorreoContacto == name.Trim())
            ); 
        }
    }

   
}
