using AutoMapper;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IBaseRepository<Provincia> _provinciaRepository;
        private readonly IMapper _mapper;

        public ProvinciaService(IBaseRepository<Provincia> provinciaRepository, IMapper mapper)
        {
            _provinciaRepository = provinciaRepository;
            _mapper = mapper;
        }

        public static IEnumerable<Provincia> Initialize()
        {
            var id = 1;
            return new List<Provincia>
            {
                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-N",
                    Nombre ="Misiones"
                },
                                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-D",
                    Nombre ="San Luis"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-J",
                    Nombre ="San Juan"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-E",
                    Nombre ="Entre Ríos"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-Z",
                    Nombre ="Santa Cruz"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-R",
                    Nombre ="Río Negro"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-U",
                    Nombre ="Chubut"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-X",
                    Nombre ="Córdoba"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-M",
                    Nombre ="Mendoza"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-F",
                    Nombre ="La Rioja"
                },
                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-K",
                    Nombre ="Catamarca"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-N",
                    Nombre ="Misiones"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-L",
                    Nombre ="La Pampa"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-G",
                    Nombre ="Santiago del Estero"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-W",
                    Nombre ="Corrientes"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-S",
                    Nombre ="Santa Fe"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-T",
                    Nombre ="Tucumán"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-Q",
                    Nombre ="Neuquén"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-A",
                    Nombre ="Salta"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-H",
                    Nombre ="Chaco"
                },new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-P",
                    Nombre ="Formosa"
                },
                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-Y",
                    Nombre ="Jujuy"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-C",
                    Nombre ="Ciudad Autónoma de Buenos Aires"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-B",
                    Nombre ="Buenos Aires"
                },                new Provincia
                {
                    IdProvincia  = id++,
                    IsoId = "AR-V",
                    Nombre ="Tierra del Fuego, Antártida e Islas del Atlántico Sur"
                }
            };
        }
    
        public async Task<IEnumerable<ProvinciaDTO>> List()
        {
            return (_mapper.Map<IEnumerable<ProvinciaDTO>>(await _provinciaRepository.ListBy())).OrderBy(s => s.Nombre);
        }

        public async Task<ProvinciaDTO> GetById(int id)
        {
            var entity = await _provinciaRepository.GetById(id);
            var dto = _mapper.Map<ProvinciaDTO>(entity);
            return dto;
        }
    }
}
