using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ITransactionHistoryService
    {
        //Task<IEnumerable<TransactionHistoryDto>> GetAllTransactionHistory(bool trackChanges);
        //Task<TransactionHistoryDto> GetTransactionHistory(int Id,bool trackChanges);
        Task<bool> CreateTransactionHistory(TransactionHistoryForCreationDto transactionHistory);
    }
}
