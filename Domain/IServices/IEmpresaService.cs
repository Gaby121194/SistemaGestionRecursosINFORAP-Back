using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDTO>> List(EmpresaFilterDTO filter = null);
        Task<EmpresaDTO> GetById(UsuarioDTO userLogged, bool isSuperUser, int id);
        Task<EmpresaDTO> Create(UsuarioDTO userLogged, EmpresaDTO empresa);
        Task<EmpresaDTO> Update(UsuarioDTO userLogged, int id, EmpresaDTO empresa);
        Task<EmpresaDTO> Activate(int id);
        Task Remove(int id);
        Task<bool> Exists(string name, int? id = null);
    }
}
