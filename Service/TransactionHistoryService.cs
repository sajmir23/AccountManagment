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
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public TransactionHistoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> CreateTransactionHistory(TransactionHistoryForCreationDto transactionHistory)
        {
            var mapTransac = _mapper.Map<TransactionsHistory>(transactionHistory);
            mapTransac.TransactionDate=DateTime.Now;
            _repository.TransactionHistory.CreateRecord(mapTransac);
            await _repository.SaveAsync();
            return true;
        }
    }
}
