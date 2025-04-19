using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CurrenciesRepository : RepositoryBase<Currencies>,ICurrenciesRepository
    {
        public CurrenciesRepository(RepositoryContext context) : base(context) { }  

        public async Task<IEnumerable<Currencies>> GetAll(bool trackChanges) 
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Currencies> GetById(int Id, bool trackChanges)
            => await FindByCondition(b => b.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void CreateRecord(Currencies currencies)=>Create(currencies);

        public void UpdateRecord(Currencies currencies) => Update(currencies);

        public void DeleteRecord(Currencies currencies)=>Delete(currencies);
    }
}

