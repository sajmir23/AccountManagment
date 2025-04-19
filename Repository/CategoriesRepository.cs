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
    public class CategoriesRepository : RepositoryBase<Category>, ICategoriesRepository
    {
        public CategoriesRepository(RepositoryContext context) : base(context) { }  
        
        public async Task<IEnumerable<Category>> GetAll(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetCategory(int Id, bool trackChanges)
            => await FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void CreateRecord(Category category)=>Create(category);

        public void UpdateRecord(Category category)=>Update(category);

        public void DeleteRecord(Category category) => Delete(category);
    }

}
