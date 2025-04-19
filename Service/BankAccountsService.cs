using AutoMapper;
using Contracts;
using Entities;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BankAccountsService :IBankAccountsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BankAccountsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BankAccountsDto>> GetAccounts(bool trackChanges)
        {
            var bankAccount = await _repository.BankAccounts.GetAll(trackChanges);
            var bank_dto= _mapper.Map<IEnumerable<BankAccountsDto>>(bankAccount);
            return bank_dto;
        }
        public async Task<BankAccountsDto> GetAccount(int Id, bool trackChanges)
        {
            var bank = await _repository.BankAccounts.Get(Id,trackChanges);
            var bank_dto=_mapper.Map<BankAccountsDto>(bank);
            return bank_dto;

        }
        public async Task<bool> Create(BankAccountForCreationDto account)
        {
            try
            {
                var bank = _mapper.Map<BankAccounts>(account);
                bank.DateCreated = DateTime.Now;
                _repository.BankAccounts.CreateAccount(bank);
                await _repository.SaveAsync();
                return true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message); 
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
          
          
        }
        public async Task<bool>Update(BankAccountForUpdateDto bankAccountsDto, int Id)
        {
            var bank = await _repository.BankAccounts.Get(Id,trackChanges:false);

            if (bank == null)
               _logger.LogInfo($"Can't found {nameof(GetAccount)}");

            _mapper.Map(bankAccountsDto, bank);

            bank.DateUpdated= DateTime.Now;

            _repository.BankAccounts.UpdateAccount(bank);

            await _repository.SaveAsync();

            return true;
        }
        public async Task<bool>Delete(int Id)
        {
            var bank = await _repository.BankAccounts.Get(Id,trackChanges:false);

            if (bank == null)
                throw new Exception("Nuk u gjend te jete krijuar me pare.");

            _repository.BankAccounts.DeleteAccount(bank);

            await _repository.SaveAsync();

            return true;
        }
    }
}
