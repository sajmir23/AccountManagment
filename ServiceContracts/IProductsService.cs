using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsDto>> GetAll(bool trackChanges);
        Task<ProductsDto> GetProduct(int Id,bool trackChanges);
        Task<bool> Create(ProductsForCreationDto product);
        Task<bool> Update(ProductsForUpdateDto product,int Id);
        Task<bool> Delete(int Id);
    }
}
