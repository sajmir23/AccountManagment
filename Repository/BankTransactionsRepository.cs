using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BankTransactionsRepository : RepositoryBase<BankTransactions>,IBankTransactionsRepository
    {
        public BankTransactionsRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<BankTransactions>> GetBankTransactions(bool trackChanges)=>
        await FindAll(trackChanges).ToListAsync(); 
        
        public async Task<BankTransactions> GetTransaction(int Id, bool trackChanges)
            => await FindByCondition(o=>o.Id.Equals(Id),trackChanges).SingleOrDefaultAsync();

        public void CreateRecord(BankTransactions transaction) => Create(transaction);

        //public void UpdateRecord(BankTransactions transaction) => Update(transaction);

        public void DeleteRecord(BankTransactions bankTransactions) => Delete(bankTransactions);
    }
}
