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
    public class CurrenciesService : ICurrenciesService
    {
         private readonly IRepositoryManager _repository;
         private readonly ILoggerManager _logger;
         private readonly IMapper _mapper;

        public CurrenciesService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CurrenciesDto>> GetCurrenciesAll(bool trackChanges)
        {
            var news = await _repository.Currencies.GetAll(trackChanges);
            var currencies=_mapper.Map<IEnumerable<CurrenciesDto>>(news);
            return currencies;
        }
        public async Task<CurrenciesDto> GetCurrencies(int id, bool trackChanges)
        {
            var newss = await _repository.Currencies.GetById(id, trackChanges);
            var newssdto = _mapper.Map<CurrenciesDto>(newss);
            return newssdto;
        }
        public async Task<bool> CreateRecord(CurrenciesForCreationDto currencies)
        {
            
            try
            {
                var newss = _mapper.Map<Currencies>(currencies);

                currencies.DateCreated= DateTime.Now;

                _repository.Currencies.CreateRecord(newss);

                await _repository.SaveAsync();

                return true;
            }
            catch(Exception ex) 
            {
                _logger.LogError(string.Format(nameof(CreateRecord),ex.Message));
                throw new Exception("Nuk mund te krijohet");
            }  
        }
        public async Task<bool> Update(CurrenciesForUpdateDto currencies, int Id)
        {
            var newId = await _repository.Currencies.GetById(Id, trackChanges:false);

            if(newId == null)
            {
                throw new Exception("Nuk u gjend me kete Id");
            }

            newId.DateUpdated= DateTime.Now;

            _mapper.Map(currencies, newId);

            _repository.Currencies.UpdateRecord(newId);

            await _repository.SaveAsync();

            return true;
        }
        public async Task<bool> Delete(int Id)
        {
            var existing = await _repository.Currencies.GetById(Id, trackChanges: false);

            if (existing == null)
            {
                throw new Exception("Nuk u gjend me kete Id");
            }

            _repository.Currencies.DeleteRecord(existing);

            await  _repository.SaveAsync();

            return true;
        }

    }
}
