using Contracts;
using Microsoft.AspNetCore.Components;
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
    [Microsoft.AspNetCore.Mvc.Route("api/controller")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public CategoryController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetAll(bool trackChanges)
        {
            var dfvb = await _service.CategoriesService.GetAllCategories(trackChanges);
            return Ok(dfvb);
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(bool trackChanges,int Id)
        {
            var dsgs = await _service.CategoriesService.GetById(Id, trackChanges);
            return Ok(dsgs);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Create([FromBody] CategoriesForCreationDto categoriesForCreation) 
        {
            await _service.CategoriesService.Create(categoriesForCreation);
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Update([FromBody] CategoriesForUpdateDto categoriesForUpdate,int Id)
        {
            var sdvsd = await _service.CategoriesService.Update(categoriesForUpdate, Id);
            return Ok();
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete(int Id)
        {
            var dsgf = await _service.CategoriesService.Delete(Id);
            return Ok(dsgf);
        }

    }
}
