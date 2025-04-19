using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBankTransactionsRepository
    {
        Task<IEnumerable<BankTransactions>> GetBankTransactions(bool trackChanges);
        Task<BankTransactions> GetTransaction(int Id,bool trackChanges);   
        void CreateRecord(BankTransactions transaction);
       // void UpdateRecord(BankTransactions transaction);  
        void DeleteRecord(BankTransactions bankTransactions);
    }
}
