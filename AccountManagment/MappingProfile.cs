using AutoMapper;
using Contracts;
using Entities;
using Shared.Dto;

namespace AccountManagment
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto,User>().ReverseMap();
            CreateMap<UserForAuthenticationDto,User>().ReverseMap();

            CreateMap<ClientforUpdateDto, Clients>().ReverseMap();
            CreateMap<ClientForCreationDto, Clients>().ReverseMap();
            CreateMap<ClientForUpdateDto, Clients>().ReverseMap();

            CreateMap<BankAccountsDto, BankAccounts>().ReverseMap();
            CreateMap<BankAccountForCreationDto, BankAccounts>().ReverseMap();
            CreateMap<BankAccountForUpdateDto, BankAccounts>().ReverseMap();

            CreateMap<BankTransactionsDto, BankTransactions>().ReverseMap();
            CreateMap<BankTransactionForCreationDto, BankTransactions>().ReverseMap();

            CreateMap<CategoriesDto, Category>().ReverseMap();
            CreateMap<CategoriesForCreationDto, Category>().ReverseMap();
            CreateMap<CategoriesForUpdateDto, Category>().ReverseMap();

            CreateMap<CurrenciesDto, Currencies>().ReverseMap();
            CreateMap<CurrenciesForCreationDto, Currencies>().ReverseMap();
            CreateMap<CurrenciesForUpdateDto, Currencies>().ReverseMap();

            CreateMap<ProductsDto, Products>().ReverseMap(); 
            CreateMap<ProductsForCreationDto, Products>().ReverseMap(); 
            CreateMap<ProductsForUpdateDto,Products>().ReverseMap();

            CreateMap<TransactionHistoryDto, TransactionsHistory>().ReverseMap();
            CreateMap<TransactionHistoryForCreationDto, TransactionsHistory>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserForCreationDto, User>().ReverseMap();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
        }
    }
}
