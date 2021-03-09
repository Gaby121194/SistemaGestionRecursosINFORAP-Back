using INFORAP.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.Domain.IServices
{
    public interface IProvinciaService
    {
        Task<IEnumerable<ProvinciaDTO>> List();
        Task<ProvinciaDTO> GetById(int id);

    }



}
