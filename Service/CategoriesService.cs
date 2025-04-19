using AutoMapper;
using Contracts;
using Entities;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoriesService : ICategoriesService
    {
         private readonly IRepositoryManager _repository;
         private readonly ILoggerManager _logger;
         private readonly IMapper _mapper;
         public CategoriesService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
         {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
         }

        public async Task<IEnumerable<CategoriesDto>> GetAllCategories(bool trackChanges)
        {
            var categ = await _repository.Categories.GetAll(trackChanges);
            var categdto=_mapper.Map<IEnumerable<CategoriesDto>>(categ);    
            return categdto;
        }
        public async Task<CategoriesDto> GetById(int Id, bool trackChanges)
        {
            var categories = await _repository.Categories.GetCategory(Id, trackChanges);
            var vategdtoss=_mapper.Map<CategoriesDto>(categories);
            return vategdtoss;
        }
        public async Task<bool> Create(CategoriesForCreationDto category)
        {
            var catdto=_mapper.Map<Category>(category);
            catdto.DateCreated = DateTime.Now;
            _repository.Categories.CreateRecord(catdto);
            await _repository.SaveAsync();
            return true;
        }
        public async Task<bool> Update(CategoriesForUpdateDto category, int Id)
        {
            var existing = await _repository.Categories.GetCategory(Id, trackChanges:false);

            if (existing == null)
                throw new Exception("Nuk gjendet.");

            existing.DateUpdated = DateTime.Now;

            _mapper.Map(category, existing);

            _repository.Categories.UpdateRecord(existing);

            await _repository.SaveAsync();

            return true;
        }
        public async Task<bool> Delete(int Id)
        {
            var existing = await _repository.Categories.GetCategory(Id, trackChanges: false);

            if (existing == null)
                throw new Exception("Nuk gjendet.");

            _repository.Categories.DeleteRecord(existing);

            await _repository.SaveAsync();

            return true;
        }
    }
}
