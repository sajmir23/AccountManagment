using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITransactionHistoryRepository
    {
       // Task<IEnumerable<TransactionsHistory>> GetAllTransactionsHistory(bool trackChanges);
        //Task<TransactionsHistory> GetTransactionHisotry(int Id, bool trackChanges);
        void CreateRecord( TransactionsHistory transactionHistory );
    }
}
