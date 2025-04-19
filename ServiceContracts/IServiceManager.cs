using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IBankAccountsService BankAccountsService { get; }
        IBankTransactionsService BankTransactionsService { get; }
        ICategoriesService CategoriesService { get; }
        IClientsService ClientsService { get; }
        ICurrenciesService CurrenciesService { get; }
        IProductsService ProductsService { get; }
        ITransactionHistoryService TransactionHistoryService { get; }
        IUserService UserService { get; }
    }
}
