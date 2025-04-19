using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetAllProducts(bool trackChanges);
        Task<Products> GetProduct(int Id, bool trackChanges);
        void CreateRecord(Products product);
        void UpdateRecord(Products product);
        void DeleteRecord(Products product);
    }
}
