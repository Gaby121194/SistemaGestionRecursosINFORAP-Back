using AutoMapper;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.MongoDb.Entities;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Mapping
{
    public class EntityToDto : Profile
    {
        public EntityToDto() {

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(s=>s.Empresa,opt=> opt.MapFrom(x=>x.Empresa))
                .ForMember(s=>s.Rol,opt=> opt.MapFrom(x=>x.Rol))
                .ForMember(s=> s.Password,opt => opt.Ignore());
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<Ubicacion, UbicacionDTO>();
            CreateMap<RecursoHumano, RecursoHumanoDTO>();
            CreateMap<RecursoMaterial, RecursoMaterialDTO>()
                .ForMember(x=>x.IdRecursoNavigation, opt=> opt.MapFrom(s=>s.IdRecursoNavigation));
            CreateMap<TipoRecursoMaterial, TipoRecursoMaterialDTO>();
            CreateMap<TipoRecursoRenovable, TipoRecursoRenovableDTO>();
            CreateMap<Estado, EstadoDTO>();
            CreateMap<RecursoRenovable, RecursoRenovableDTO>();
            CreateMap<TipoRecurso, TipoRecursoDTO>();
            CreateMap<Recurso, RecursoDTO>();
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<Controlador, ControladorDTO>();
            CreateMap<Permiso, PermisoDTO>();
            CreateMap<StockRecursoMaterial, StockRecursoMaterialDTO>();
            CreateMap<Servicio, ServicioDTO>()
                .ForMember(s=>s.Cliente, opt=>opt.MapFrom(x=>x.IdClienteNavigation));
            CreateMap<Requisito, RequisitoDTO>();
            CreateMap<TipoRegla, TipoReglaDTO>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<RecursoAsignado, RecursoAsignadoDTO>();
            CreateMap<ServicioRecurso, RecursoServicioDTO>();
                 //.ForMember(s => s.Servicio, opt => opt.MapFrom(x => x.IdServicioNavigation));
            CreateMap<ServicioRecurso, ServicioRecursoDTO>()
                .ForMember(s => s.Recurso, opt => opt.MapFrom(x => x.IdRecursoNavigation))
                .ForMember(s => s.TipoRecurso, opt => opt.MapFrom(x => x.IdRecursoNavigation.IdTipoRecursoNavigation));
            CreateMap<MotivoBajaServicio, MotivoBajaServicioDTO>();
            //  CreateMap<Backup, BackupDTO>(); 
            CreateMap<DBBackup,BackupDTO>(); ;

        }

    }
}
