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
    public class CurrenciesController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public CurrenciesController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllCurrencies")]
        public async Task<IActionResult> GetAll(bool trackChanges)
        {
            var needd = await _service.CurrenciesService.GetCurrenciesAll(trackChanges);
            return Ok(needd);
        }
        [HttpGet("GetCurrency")]
        public async Task<IActionResult> GetById(int Id,bool trackChanges)
        {
            var dfvs = await _service.CurrenciesService.GetCurrencies(Id,trackChanges);
            return Ok(dfvs);
        }
        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateRecord([FromBody] CurrenciesForCreationDto currenciesForCreation)
        {
            if (currenciesForCreation is null)
            {
                return BadRequest("bankTransactionsDto object is null.");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var existing = await _service.CurrenciesService.CreateRecord(currenciesForCreation);
            return Ok();
        }
        [HttpPut("UpdateCurrency")]
        public async Task<IActionResult> UpdateRecord([FromBody] CurrenciesForUpdateDto currencies,int Id)
        {
            if (currencies is null)
            {
                return BadRequest("bankTransactionsDto object is null.");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var ffgetdto = await _service.CurrenciesService.Update(currencies, Id);

            return Ok(ffgetdto);
        }
        [HttpDelete("DeleteCurrency")]
        public async Task<IActionResult> DeleteRecord(int Id)
        {
            var currencies = await _service.CurrenciesService.Delete(Id);
            return Ok(currencies);
        }

    }
}

    

