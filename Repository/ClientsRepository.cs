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
    public class ClientsRepository : RepositoryBase<Clients>,IClientsRepository
    {
        public ClientsRepository(RepositoryContext context) : base(context) { } 
        
        public async Task<IEnumerable<Clients>> GetAllClients(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Clients> GetClient(int Id, bool trackChanges)
            => await FindByCondition(o => o.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void CreateClient(Clients clients)=> Create(clients);

        public void UpdateClient(Clients clients) => Update(clients);
      
        public void DeleteClient(Clients clients) => Delete(clients);
    }
}
