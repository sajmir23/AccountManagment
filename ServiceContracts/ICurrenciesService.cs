using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICurrenciesService
    {
        Task<IEnumerable<CurrenciesDto>> GetCurrenciesAll(bool trackChanges);
        Task<CurrenciesDto> GetCurrencies(int id, bool trackChanges);
        Task<bool> CreateRecord(CurrenciesForCreationDto currencies);
        Task<bool> Update(CurrenciesForUpdateDto currencies,int Id);
        Task<bool> Delete(int Id);
    }
}
