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
    public class BankAccountsRepository : RepositoryBase<BankAccounts> ,IBankAccountsRepository
    {
        public BankAccountsRepository(RepositoryContext context):base(context) { }

        public async Task<IEnumerable<BankAccounts>> GetAll(bool trackChanges) 
            => await FindAll(trackChanges).ToListAsync();

        public async Task<BankAccounts> Get(int Id, bool trackChanges)
            => await FindByCondition(o=>o.Id.Equals(Id),trackChanges).SingleOrDefaultAsync();

        public void CreateAccount(BankAccounts bankAccount)=> Create(bankAccount);

        //bankAccount.ClientId = ClientId;
        //bankAccount.CurrenciesId = CurrenciesId;

        public void UpdateAccount(BankAccounts bankAccount) => Update(bankAccount);

        public void DeleteAccount(BankAccounts bankAccount)=> Delete(bankAccount);

        //bankAccount.ClientId = ClientId;
        //bankAccount.CurrenciesId = CurrenciesId;
    }
}
