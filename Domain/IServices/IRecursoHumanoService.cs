using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IRecursoHumanoService
    {
        Task<IEnumerable<RecursoHumanoDTO>> List(RecursoHumanoFilterDTO filter = null);
        Task<RecursoHumanoDTO> GetById(UsuarioDTO userLogged, int id);
        Task<RecursoHumanoDTO> Create(UsuarioDTO userLogged, RecursoHumanoDTO recursoHumano);
        Task<RecursoHumanoDTO> Update(UsuarioDTO userLogged, int id, RecursoHumanoDTO recursoHumano);
        Task<bool> Remove(UsuarioDTO userLogged, int id);
        Task<bool> Exists(string name, int idEmpresa, int? id = null);
        //Task<IEnumerable<RecursoHumanoDTO>> Initialize(UsuarioDTO user);
        Task<IEnumerable<RecursoHumanoDTO>> ListRecursosHumanosAvailables(UsuarioDTO currUser, int? idServicio = null);
        Task<IEnumerable<RecursoHumanoDTO>> ListRecursosHumanosWithOutUser(UsuarioDTO currUser,int? idRecursoHumano  = null);



    }
}
