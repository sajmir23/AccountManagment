using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TransactionHistoryRepository : RepositoryBase<TransactionsHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(RepositoryContext context) : base(context) { }


        public void CreateRecord(TransactionsHistory transactionHistory) => Create(transactionHistory);

    }
}
   
