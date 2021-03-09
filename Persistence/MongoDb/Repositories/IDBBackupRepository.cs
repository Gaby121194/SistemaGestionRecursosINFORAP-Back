using INFORAP.API.DTOs;
using INFORAP.API.Persistence.MongoDb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.MongoDb.Repositories
{
    public interface IDBBackupRepository
    {
        Task<IEnumerable<DBBackup>> List(BackupFilterDTO filter);
        Task<DBBackup> GetBy(string id);
        Task<DBBackup> Create(DBBackup backup);
    }
}