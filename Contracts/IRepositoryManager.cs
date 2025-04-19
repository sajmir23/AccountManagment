using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IBankAccountsRepository BankAccounts { get; }
        IBankTransactionsRepository BankTransactions { get; }
        IProductsRepository Products { get; }
        IClientsRepository Clients { get; }
        ICategoriesRepository Categories { get; }
        ICurrenciesRepository Currencies { get; }
        ITransactionHistoryRepository TransactionHistory { get; }
        IUserRepository User { get; }

        Task SaveAsync();
    }
}
