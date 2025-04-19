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
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAll(bool trackChanges)=>
            await FindAll(trackChanges).ToListAsync();

        public async Task<User> GetUserById(int Id, bool trackChanges)
            => await FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void CreateUser(User user) => Create(user);

        public void UpdateUser(User user) => Update(user);

        public void DeleteUser(User user) => Delete(user);
    }
}
