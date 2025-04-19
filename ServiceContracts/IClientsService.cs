using Entities;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientforUpdateDto>> GetAll(bool trackChanges);
        Task<ClientforUpdateDto> GetClient(int Id,bool trackChanges);
        Task<bool> Create(ClientForCreationDto clientForCreationDto);
        Task<bool> Update(ClientForUpdateDto clientForUpdateDto,int Id);
        Task<bool> Delete(int Id);
    }
}