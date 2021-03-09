using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IServicioService
    {
        Task<IEnumerable<ServicioDTO>> ListBy(int idEmpresa, ServicioFilterDTO filter);
        Task<ServicioDTO> GetBy(int id);
        Task<ServicioDTO> Create(ServicioDTO dto, UsuarioDTO user);
        Task<ServicioDTO> Update(int id, ServicioDTO dto, UsuarioDTO user);
        Task Remove(int id, int idMotivoBaja,string observaciones, UsuarioDTO user);
        Task RemoveAsEnding(int id);
        Task<int> GenerateContractNumber(int idEmpresa);
        Task<bool> Exists(string name, int idEmpresa, int? id = null);
        Task<IEnumerable<CantidadRecursosAgrupadosMesDTO>> GetHumanResourcesGroupedByMonths(DateTime from, DateTime to, int idServicio, UsuarioDTO currUser);
        Task<IEnumerable<CantidadServiciosActivosMesDTO>> GetActiveServicesGroupedByMonths(DateTime from, DateTime to, UsuarioDTO currUser);
        Task<ServiciosActivosInactivosDTO> GetServiciosActivosInactivos(DateTime from, DateTime to, UsuarioDTO currUser);
        Task<ServiciosInactivosMotivosDTO> GetServiciosInactivosMotivos(DateTime from, DateTime to, UsuarioDTO currUser);

    }
}