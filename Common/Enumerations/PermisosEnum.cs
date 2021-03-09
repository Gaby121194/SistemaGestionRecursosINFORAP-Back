using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Common.Enumerations
{

    public enum PermisosEnum
    {
        [Description("ADMIN")]
        ADMIN = 1,
        [Description("MANAGER")]
        MANAGER = 2,
        [Description("SERVICE-USER")]
        SERVICE_USER =3,
        [Description("RRHH-USER")]
        RRHH_USER = 4
    }



}
