using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRecursoMaterialService
    {
        Task<IEnumerable<RecursoMaterialDTO>> List(UsuarioDTO userlogged, RecursosMaterialesFilterDTO filter = null);
        Task<RecursoMaterialDTO> GetById(UsuarioDTO userLogged, int id);
        Task<RecursoMaterialDTO> Create(UsuarioDTO userLogged, RecursoMaterialDTO dto);
        Task<RecursoMaterialDTO> Update(UsuarioDTO userLogged, int id, RecursoMaterialDTO dto);
        Task<bool> Remove(UsuarioDTO loggedUser, int id);
        Task<bool> StartOutOfService(UsuarioDTO loggedUser, int id);
        Task<bool> EndOutOfService(UsuarioDTO loggedUser, int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);
        Task<IEnumerable<RecursoMaterialDTO>> ListRecursosMaterialesAvailables(int idServicio,UsuarioDTO currUser);

        Task<IEnumerable<RecursoMaterialDTO>> ListRRMMFromRecurso(int idRecurso1, UsuarioDTO currUser);

    }
}
