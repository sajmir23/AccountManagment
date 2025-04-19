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
    public class ProductsRepository : RepositoryBase<Products>,IProductsRepository
    {
        public ProductsRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Products>> GetAllProducts(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Products> GetProduct(int Id, bool trackChanges)
            => await FindByCondition(y => y.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void CreateRecord(Products product)=>Create(product);

        public void UpdateRecord(Products product)=>Update(product);

        public void DeleteRecord(Products product) => Delete(product);
    }
}
