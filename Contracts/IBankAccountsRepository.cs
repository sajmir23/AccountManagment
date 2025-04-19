using Entities;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBankAccountsRepository
    {
        Task<IEnumerable<BankAccounts>> GetAll(bool trackChanges);
        Task<BankAccounts> Get(int AccountId,bool trackChanges);
        void CreateAccount(BankAccounts bankAccount);
        void UpdateAccount(BankAccounts bankAccount);
        void DeleteAccount(BankAccounts bankAccounts);
    }
}
