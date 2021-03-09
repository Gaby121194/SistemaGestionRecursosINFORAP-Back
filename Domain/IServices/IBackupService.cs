using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IBackupService
    {
        Task<BackupDTO> GetByKey(string key);
        Task<IEnumerable<BackupDTO>> List(BackupFilterDTO filter);
        Task<string> GetBackup(string key);
        Task Insert(string script, string fileName = "");
    }
}
