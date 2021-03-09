using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IStockRecursoMaterialService
    {
        Task<IEnumerable<StockRecursoMaterialDTO>> List(UsuarioDTO UserLogged,int id, StockRecursoMaterialFilterDTO filter = null);
        Task<StockRecursoMaterialDTO> GetById(UsuarioDTO userLogged, int id);
        Task<StockRecursoMaterialDTO> Create(UsuarioDTO userLogged, StockRecursoMaterialDTO dto);
        Task<bool> DismiuyeUno(int idUbicacion, int idRecurso);
        Task<bool> AumentaUno(int idUbicacion, int idRecurso);
        Task<StockRecursoMaterialDTO> Update(UsuarioDTO userLogged, int id, StockRecursoMaterialDTO dto);
        Task<bool> Remove(int id);
        Task<bool> Exists(UsuarioDTO userLogged, string name, int? id = null);
    }
}
