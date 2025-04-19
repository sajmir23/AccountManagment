using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBankAccountsService> _bankAccountsService;
        private readonly Lazy<IBankTransactionsService> _bankTransactionsService;
        private readonly Lazy<ICategoriesService> _categoriesService;
        private readonly Lazy<ICurrenciesService> _currenciesService;
        private readonly Lazy<IProductsService> _productsService;
        private readonly Lazy<IClientsService> _clientsService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<ITransactionHistoryService> _transactionHistoryService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repository,ILoggerManager logger,IMapper mapper,UserManager<User> userManager,IConfiguration configuration)
        {
            _bankAccountsService = new Lazy<IBankAccountsService>(() => new
             BankAccountsService(repository, logger, mapper));

            _bankTransactionsService = new Lazy<IBankTransactionsService>(() => new
            BankTransactionsService(repository,logger,mapper));
 
            _categoriesService = new Lazy<ICategoriesService>(() => new
            CategoriesService(repository, logger, mapper));

            _currenciesService = new Lazy<ICurrenciesService>(() => new
            CurrenciesService(repository, logger, mapper));

            _productsService = new Lazy<IProductsService>(() => new
            ProductsService(repository, logger, mapper));

            _clientsService = new Lazy<IClientsService>(() => new
            ClientsService(repository, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() => new
            AuthenticationService( logger, mapper, userManager,configuration));

            _transactionHistoryService = new Lazy<ITransactionHistoryService>(() => new
            TransactionHistoryService(repository, logger, mapper));

            _userService = new Lazy<IUserService>(() => new
            UserService(repository, logger, mapper));
        }
        
        public IBankAccountsService BankAccountsService => _bankAccountsService.Value;
        public IBankTransactionsService BankTransactionsService => _bankTransactionsService.Value;
        public ICategoriesService CategoriesService => _categoriesService.Value;
        public ICurrenciesService CurrenciesService => _currenciesService.Value;
        public IClientsService ClientsService => _clientsService.Value;
        public IProductsService ProductsService => _productsService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ITransactionHistoryService TransactionHistoryService => _transactionHistoryService.Value;
        public IUserService UserService => _userService.Value;

    }
}
