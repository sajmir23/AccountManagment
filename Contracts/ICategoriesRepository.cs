using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAll(bool trackChanges);
        Task<Category> GetCategory(int Id,bool trackChanges);
        void CreateRecord(Category category);
        void UpdateRecord(Category category);
        void DeleteRecord(Category category);
    }
}
