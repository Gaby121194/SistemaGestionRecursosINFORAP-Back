using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class PermisoControladorAccionService
    {
        public static IEnumerable<PermisoControladorAccion> Initialize()
        {
            var result = new List<PermisoControladorAccion>();
            var id = 1;
            //ADMIN
            result.AddRange(new List<PermisoControladorAccion>
            {
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.ADMIN.ToInt(),
                    ControladorId = ControladorEnum.Usuarios.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.ADMIN.ToInt(),
                    ControladorId = ControladorEnum.Empresas.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.ADMIN.ToInt(),
                    ControladorId = ControladorEnum.Backups.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.ADMIN.ToInt(),
                    ControladorId = ControladorEnum.Permisos.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.ADMIN.ToInt(),
                    ControladorId = ControladorEnum.Views.ToInt()
                }
            });

            //MANAGER
            result.AddRange(new List<PermisoControladorAccion>
            {
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.MANAGER.ToInt(),
                    ControladorId = ControladorEnum.Usuarios.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.MANAGER.ToInt(),
                    ControladorId = ControladorEnum.Roles.ToInt()
                }
            });

            //RRHH USER
            result.AddRange(new List<PermisoControladorAccion>
            {
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.RRHH_USER.ToInt(),
                    ControladorId = ControladorEnum.Recursoshumanos.ToInt()
                }
            });

            //SERVICE
            result.AddRange(new List<PermisoControladorAccion>
            {
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.RecursosMateriales.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.Clientes.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.Servicios.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.Recursosrenovables.ToInt()
                },
                new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.Ubicaciones.ToInt()
                },
                   new PermisoControladorAccion
                {
                    Id = id++,
                    PermisoId = PermisosEnum.SERVICE_USER.ToInt(),
                    ControladorId = ControladorEnum.Alertas.ToInt()
                }
            });
            return result;
        }
    }
}
