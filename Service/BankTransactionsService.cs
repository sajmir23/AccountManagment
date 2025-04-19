using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using ServiceContracts;
using Shared.Dto;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BankTransactionsService : IBankTransactionsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BankTransactionsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BankTransactionsDto>> GetBankTransactions(bool trackChanges)
        {
            var benaks = await _repository.BankTransactions.GetBankTransactions(trackChanges);
            var banks = _mapper.Map<IEnumerable<BankTransactionsDto>>(benaks);
            return banks;
        }

        public async Task<BankTransactionsDto> GetBankTransaction(int Id, bool trackChanges)
        {
            var bankss= await GetTransactionAndCheckIfExist(Id, trackChanges);   
            var bank_dto=_mapper.Map<BankTransactionsDto>(bankss);  
            return bank_dto;
        }

        public async Task<bool> CreateRecord(BankTransactionForCreationDto bankTransaction,int AccountId)
        {
            try
            {
                var account_exist = await _repository.BankAccounts.Get(AccountId, trackChanges: true);
                if(account_exist == null)
                {
                    return false;
                }

                var bankdto = _mapper.Map<BankTransactions>(bankTransaction);

                bankdto.DateCreated = DateTime.Now;

                decimal balanceAferTransaction = account_exist.Balance;

                if (bankTransaction.Action == ActionEnum.Deposit)
                {
                    account_exist.Balance += bankTransaction.Amount;
                    balanceAferTransaction = account_exist.Balance;
                }
                else if(bankTransaction.Action == ActionEnum.Withdraw)
                {
                    if (account_exist.Balance < bankTransaction.Amount)
                    {
                        _logger.LogWarning("Tentative terheqje me shume sesa balanca aktuale");
                        return false;
                    }
                    account_exist.Balance -= bankTransaction.Amount;
                    balanceAferTransaction = account_exist.Balance;
                }

                var transc_history = new TransactionsHistory
                {
                    Action = bankTransaction.Action,
                    BankAccountId = AccountId,
                    Description = bankTransaction.Description,
                    Amount = bankTransaction.Amount,
                    TransactionDate = DateTime.Now,
                    BalanceAferTransaction = balanceAferTransaction
                };

                _repository.BankTransactions.CreateRecord(bankdto);
                _repository.TransactionHistory.CreateRecord(transc_history);

                await _repository.SaveAsync();

                return true;
            }
            catch (Exception ex) 
            {
                _logger.LogError(string.Format(nameof(CreateRecord),ex.Message));
                throw;
            }
        }
        /*
        public async Task<bool> UpdateRecord(BankTransactionForUpdateDto bankTransaction, int Id)
        {
            try
            {
                var existing = await GetTransactionAndCheckIfExist(Id, trackChanges: false);

                if (existing == null)
                    throw new Exception("Nuk figuron te jete krijuar.");

                existing.DateUpdated = DateTime.Now;

                _mapper.Map(bankTransaction, existing);
                
                _repository.BankTransactions.UpdateRecord(existing);

                await _repository.SaveAsync();

                return true;
            }
            catch(Exception ex) 
            {
                _logger.LogError(string.Format(nameof(UpdateRecord), ex.Message));
                throw new Exception("Nuk mund te perditesohet.");
            }
        }
        */

        public async Task<bool> Delete(int AccountId,int TransactionId)
        {
            var transaction_existing = await GetTransactionAndCheckIfExist(TransactionId, trackChanges:true);

            if(transaction_existing == null) { return false; }

            var account_exist = await GetAccountAndCheckIfExist(AccountId, trackChanges: true);
           
            if(account_exist == null) { return false; }

            if (account_exist != null && transaction_existing != null)
            {
                if (transaction_existing.Action == ActionEnum.Deposit)
                {
                    account_exist.Balance -= transaction_existing.Amount;
                }
                   
                else if(transaction_existing.Action == ActionEnum.Withdraw)
                {
                    account_exist.Balance += transaction_existing.Amount;
                }
                transaction_existing.IsActive = false;

                transaction_existing.DateUpdated = DateTime.UtcNow;

                _repository.BankTransactions.DeleteRecord(transaction_existing);

                await _repository.SaveAsync();
                
            }
               return true;
        }


        private async Task<BankTransactions> GetTransactionAndCheckIfExist(int TransactionId,bool trackChanges)
        {
            var exist = await _repository.BankTransactions.GetTransaction(TransactionId, trackChanges);
            if (exist == null)
            {
                throw new Exception($"Nuk u gjend asnje transaksion me ID: {TransactionId}.");
            }
            return exist;
        }

        private async Task<BankAccounts> GetAccountAndCheckIfExist(int AccountId, bool trackChanges)
        {
            var exist = await _repository.BankAccounts.Get(AccountId, trackChanges);
            if (exist == null)
            {
                throw new Exception($"Nuk u gjend asnje account me ID: {AccountId}.");
            }
            return exist;
        }

        
    }
}

