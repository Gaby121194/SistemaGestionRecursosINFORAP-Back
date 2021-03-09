using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class AuthenticationTokenDTO
    {
        public string Token { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public IEnumerable<PermisoDTO> Permisos { get; set; }
        public IEnumerable<ControladorDTO> Views { get; set; }
        public bool? IsSuperUser { get; set; }
    }
}
