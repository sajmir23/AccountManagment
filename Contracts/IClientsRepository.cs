using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Clients>> GetAllClients(bool trackChanges);
        Task<Clients> GetClient(int Id,bool trackChanges);
        void CreateClient(Clients clients);
        void UpdateClient(Clients clients);
        void DeleteClient(Clients clients);
    }
}
