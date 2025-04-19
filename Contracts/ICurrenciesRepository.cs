using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICurrenciesRepository
    {
        Task<IEnumerable<Currencies>> GetAll(bool trackChanges);
        Task<Currencies> GetById(int Id,bool trackChanges);
        void CreateRecord (Currencies currencies);
        void UpdateRecord (Currencies currencies);
        void DeleteRecord (Currencies currencies);
    }
}
