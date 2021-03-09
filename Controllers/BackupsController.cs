using INFORAP.API.Common.Enumerations;
using INFORAP.API.Common.Exceptions;
using INFORAP.API.Common.Security;
using INFORAP.API.Domain.IServices;
using INFORAP.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INFORAP.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize("ADMIN")]
    public class BackupsController : BaseController
    {
        private readonly IDatabaseService _databaseService;
        private readonly IBackupService _backupService;
 
        public BackupsController(IDatabaseService databaseService, IBackupService backupService)
        {
            _databaseService = databaseService;
            _backupService = backupService;
         }

        [HttpGet]
        public async Task<IActionResult> List(DateTime? creationDateFrom, DateTime? creationDateTo)
        {
            try
            {
                return Ok(await _backupService.List(new BackupFilterDTO(creationDateFrom,creationDateTo)));
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        [HttpDelete("{fileKey}")]
        public async Task<IActionResult> Restore(string fileKey)
        {
            try
            {
                while (BackgroundServices.AlertBackgroudService.InProgress || BackgroundServices.ServicesBackgroudService.InProgress)
                {
                    Thread.Sleep(5000);
                }
                
                var _file = await _backupService.GetBackup(fileKey);
                var script = new StringBuilder();
                script.Append(await _databaseService.ScriptDrops());
                script.Append(await _databaseService.ScriptSchemaAndData());
                await _databaseService.Restore(_file);
                await _backupService.Insert(script.ToString());
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
    }
}
