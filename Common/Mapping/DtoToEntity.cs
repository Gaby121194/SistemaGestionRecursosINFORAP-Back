using AutoMapper;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.MongoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<RolDTO, Rol>();
            CreateMap<UbicacionDTO, Ubicacion>();
            CreateMap<RecursoHumanoDTO, RecursoHumano>();
            CreateMap<RecursoMaterialDTO, RecursoMaterial>();
            CreateMap<TipoRecursoMaterialDTO, TipoRecursoMaterial>();
            CreateMap<EstadoDTO, Estado>();
            CreateMap<RecursoRenovableDTO, RecursoRenovable>();
            CreateMap<TipoRecursoRenovableDTO, TipoRecursoRenovable>();
            CreateMap<TipoRecursoDTO, TipoRecurso>();
            CreateMap<RecursoDTO, Recurso>();
            CreateMap<ProvinciaDTO, Provincia>();
            CreateMap<ControladorDTO, Controlador>();
            CreateMap<PermisoDTO, Permiso>();
            CreateMap<RecursoMaterialDTO, RecursoDTO>();
            CreateMap<RecursoMaterialDTO, Recurso>();
            CreateMap<StockRecursoMaterialDTO, StockRecursoMaterial>();
            CreateMap<ServicioDTO, Servicio>()
                .ForMember(s => s.CreationDate, opt => opt.Ignore())
                .ForMember(s => s.CreationUserId, opt => opt.Ignore())
                .ForMember(s => s.Active, opt => opt.Ignore())
                .ForMember(s => s.IdEmpresa, opt => opt.Ignore());
            CreateMap<RequisitoDTO, Requisito>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<TipoReglaDTO, TipoRegla>();
            CreateMap<RecursoAsignadoDTO, RecursoAsignado>();
            CreateMap<RecursoServicioDTO, ServicioRecurso>();
            CreateMap<ServicioRecursoDTO, ServicioRecurso>()
                .ForMember(s => s.IdRecursoNavigation, opt=>opt.Ignore());
            CreateMap<MotivoBajaServicioDTO, MotivoBajaServicio>();
             //  CreateMap<BackupDTO, Backup>(); 
            CreateMap<BackupDTO, DBBackup>(); 


        }
    }
}
