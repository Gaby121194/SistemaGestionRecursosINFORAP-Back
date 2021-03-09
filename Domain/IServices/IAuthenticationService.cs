using INFORAP.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IAuthenticationService
    {
        Task<AuthenticationTokenDTO> Authenticate(AuthenticationDTO dto);
        Task<IEnumerable<ControladorDTO>> GetViews(int idRol);
    }
}