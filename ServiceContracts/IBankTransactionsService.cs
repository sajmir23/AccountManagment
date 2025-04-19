using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IBankTransactionsService
    {
        Task<IEnumerable<BankTransactionsDto>> GetBankTransactions(bool trackChanges);
        Task<BankTransactionsDto> GetBankTransaction(int Id,bool trackChanges);
        Task<bool> CreateRecord(BankTransactionForCreationDto bankTransaction,int AccountId);
       // Task<bool> UpdateRecord(BankTransactionForUpdateDto bankTransaction,int Id);
        Task<bool> Delete(int TransactionId,int AccountId);
    }
}
