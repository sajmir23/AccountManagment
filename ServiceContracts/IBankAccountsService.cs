using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IBankAccountsService
    {
        Task<IEnumerable<BankAccountsDto>> GetAccounts(bool trackChanges);
        Task<BankAccountsDto> GetAccount(int Id,bool trackChanges);
        Task<bool> Create (BankAccountForCreationDto account);
        Task<bool> Update (BankAccountForUpdateDto bankAccountsDto, int Id);
        Task<bool> Delete (int Id);
    }
}
