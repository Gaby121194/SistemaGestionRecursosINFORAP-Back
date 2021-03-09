using AutoMapper;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Extensions;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.Services
{
    public class BackupService : IBackupService
    {
        //  private readonly IBaseRepository<Backup> _backupRepository;
        private readonly IDBBackupRepository _backupRepository;
        private readonly IMapper _mapper;

        public BackupService(IDBBackupRepository backupRepository, IMapper mapper)
        {
            _backupRepository = backupRepository;
            _mapper = mapper;
        }

        public async Task<BackupDTO> GetByKey(string key)
        {
            var entity = await _backupRepository.GetBy(key);
            if (entity == null) throw new NotFoundException();
            var dto = _mapper.Map<BackupDTO>(entity);
            return dto;
        }
        public async Task<string> GetBackup(string key)
        {
            var entity = await _backupRepository.GetBy(key);
            if (entity == null) throw new NotFoundException();    
            return entity.Backup.Base64Decode();
        }

        public async Task<IEnumerable<BackupDTO>> List(BackupFilterDTO filter)
        {
            var entities = await _backupRepository.List(filter);
            var dtos = _mapper.Map<List<BackupDTO>>(entities);
            return dtos;
        }

        public async Task Insert(string script, string fileName = "")
        {
            var bck = new Persistence.MongoDb.Entities.DBBackup();
            bck.Active = true;
            bck.UpdateDate = bck.CreationDate = DateTime.Now;
            bck.UpdateUserId = bck.CreationUserId = 0;
            bck.Name = fileName.IsNullOrEmpty() ? DateTime.Now.ToString("yyyyMMddHHmmss") + "_bck_" + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_NAME") : fileName ;
            bck.Backup = script.ToString().Base64Encode();
            await _backupRepository.Create(bck);
        }

       
    }
}
