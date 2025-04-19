using Contracts;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagment.Presentation.Controller
{
    [Route("api/controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public ProductController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProducts(bool trackChanges) 
        {
            var sdgs = await _service.ProductsService.GetAll(trackChanges);
            return Ok(sdgs);
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProducts(bool trackChanges, int Id)
        {
            var sfsdf = await _service.ProductsService.GetProduct(Id, trackChanges);
            return Ok(sfsdf);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create([FromBody] ProductsForCreationDto forCreationDto)
        {
            await _service.ProductsService.Create(forCreationDto);
            return Ok();
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody] ProductsForUpdateDto productsForUpdate,int Id)
        {
            var sdgsdg = await _service.ProductsService.Update(productsForUpdate, Id);
            return Ok(sdgsdg);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(int Id)
        {
            var sdfs = await _service.ProductsService.Delete(Id);
            return Ok(sdfs);    
        }

    }
}
