using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBankAccountsRepository> _bankAccounts;
        private readonly Lazy<IBankTransactionsRepository> _bankTransactions;
        private readonly Lazy<ICategoriesRepository> _categories;
        private readonly Lazy<IClientsRepository> _clients;
        private readonly Lazy<ICurrenciesRepository> _currencies;
        private readonly Lazy<IProductsRepository> _products;
        private readonly Lazy<ITransactionHistoryRepository> _transactionHistory;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _bankAccounts = new Lazy<IBankAccountsRepository>(() =>
            new BankAccountsRepository(repositoryContext));

            _bankTransactions=new Lazy<IBankTransactionsRepository>(() =>
            new BankTransactionsRepository(repositoryContext));

            _categories = new Lazy<ICategoriesRepository>(() => 
            new CategoriesRepository(repositoryContext));

            _clients = new Lazy<IClientsRepository>(() => 
            new ClientsRepository(repositoryContext));

            _currencies = new Lazy<ICurrenciesRepository>(() =>
            new CurrenciesRepository(repositoryContext));

            _products = new Lazy<IProductsRepository>(() => 
            new ProductsRepository(repositoryContext));

            _transactionHistory = new Lazy<ITransactionHistoryRepository>(() =>
            new TransactionHistoryRepository(repositoryContext));

            _userRepository = new Lazy<IUserRepository>(() => 
            new UserRepository(repositoryContext));
        }

        public IBankAccountsRepository BankAccounts => _bankAccounts.Value;
        public IBankTransactionsRepository BankTransactions  => _bankTransactions.Value;
        public ICategoriesRepository Categories => _categories.Value;
        public IClientsRepository Clients => _clients.Value;
        public ICurrenciesRepository Currencies => _currencies.Value;
        public IProductsRepository Products => _products.Value;
        public ITransactionHistoryRepository TransactionHistory => _transactionHistory.Value;
        public IUserRepository User => _userRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
