using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoriesDto>> GetAllCategories(bool trackChanges);
        Task<CategoriesDto> GetById(int Id,bool trackChanges);
        Task<bool> Create(CategoriesForCreationDto category);
        Task<bool> Update(CategoriesForUpdateDto category,int Id);
        Task<bool> Delete(int Id);
    }
}
