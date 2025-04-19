using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductsService : IProductsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDto>> GetAll(bool trackChanges)
        {
            var kjvlk = await _repository.Products.GetAllProducts(trackChanges);
            var wsgfsdsd=_mapper.Map<IEnumerable<ProductsDto>>(kjvlk);
            return wsgfsdsd;
        }
        public async Task<ProductsDto> GetProduct(int Id, bool trackChanges)
        {
            var kjvlk = await _repository.Products.GetProduct(Id,trackChanges);
            var wsgfsdsd = _mapper.Map<ProductsDto>(kjvlk);
            return wsgfsdsd;
        }
        
        public async Task<bool> Create(ProductsForCreationDto product)
        {
            var dgd =_mapper.Map<Products>(product);
            dgd.Created= DateTime.Now;
            _repository.Products.CreateRecord(dgd);
            await _repository.SaveAsync();
            return true;

        }
        public async Task<bool> Update(ProductsForUpdateDto product, int Id)
        {
            var existing = await _repository.Products.GetProduct(Id, trackChanges: false);

            if (existing == null)
                throw new Exception("Nuk u gjend.");

            _mapper.Map(product,existing);

            existing.Updated=DateTime.Now;

            _repository.Products.UpdateRecord(existing);

            await _repository.SaveAsync();

            return true;

        }
        public async Task<bool> Delete(int Id)
        {
            var existing = await _repository.Products.GetProduct(Id, trackChanges: false);

            if (existing == null)
                throw new Exception("Nuk u gjend.");

            _repository.Products.DeleteRecord(existing);

            await _repository.SaveAsync();

            return true;
        }
    }
}
