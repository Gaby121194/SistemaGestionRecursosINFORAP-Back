using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IDatabaseService
    {
        Task Restore(string schemaScript);
        Task<string> ScriptSchemaAndData();
        Task<string> ScriptDrops();
    }
}
