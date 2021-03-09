using INFORAP.API.Common.Security;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.MongoDb.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.MongoDb.Repositories
{
    public class DBBackupRepository : IDBBackupRepository
    {
        private readonly IMongoCollection<DBBackup> _backupCollection;

        public DBBackupRepository(IInforapMongoConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _backupCollection = database.GetCollection<DBBackup>("Backup");
        }
        public async Task<IEnumerable<DBBackup>> List(BackupFilterDTO filter)
        {
            //return await _backupCollection.AsQueryable().Where(s => s.Active == true
            //&& ((filter.CreationDateFrom == null || s.CreationDate >= filter.CreationDateFrom)
            //&& (filter.CreationDateTo == null || s.CreationDate <= filter.CreationDateTo))
            //).Select(s => new DBBackup
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    CreationDate = s.CreationDate
            //}).ToListAsync();
            var result = _backupCollection.Find(s => s.Active == true
              && ((filter.CreationDateFrom == null || s.CreationDate >= filter.CreationDateFrom)
            && (filter.CreationDateTo == null || s.CreationDate <= filter.CreationDateTo))
            ).ToList();

            return result.Select(s => new DBBackup
            {
                Id = s.Id,
                Name = s.Name,
                CreationDate = s.CreationDate
            }).ToList();
        }

        public async Task<DBBackup> GetBy(string id) => await _backupCollection.Find(s => s.Active == true && s.Id == id).FirstOrDefaultAsync();

        public async Task<DBBackup> Create(DBBackup backup)
        {
            await _backupCollection.InsertOneAsync(backup);
            return backup;
        }
    }
}
