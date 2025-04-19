using Contracts;
using Microsoft.AspNetCore.Authorization;
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
    public class BankAccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public BankAccountController(IServiceManager service,ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("GetAccounts")]
        public async Task<IActionResult> GetAccounts(bool trackChanges)
        {
            var account = await _service.BankAccountsService.GetAccounts(trackChanges);
            return Ok(account);
        }
        //[Authorize]
        [HttpGet("GetAccount")]
        public async Task<IActionResult> GetAccount(int Id,bool trackChanges)
        {
            var account = await _service.BankAccountsService.GetAccount(Id,trackChanges);
            return Ok(account);
        }
        //[Authorize]
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] BankAccountForCreationDto bankAccountForCreationDto)
        {
            if (bankAccountForCreationDto is null)
            {
                return BadRequest("bankTransactionsDto object is null.");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.BankAccountsService.Create(bankAccountForCreationDto);
            return Ok();
        }
        //[Authorize]
        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] BankAccountForUpdateDto bankAccountsDto,int Id)
        {
            await _service.BankAccountsService.Update(bankAccountsDto,Id);
            return Ok();
        }
        //[Authorize]
        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int Id)
        {
            var bank_delete = await _service.BankAccountsService.Delete(Id);
            return Ok(bank_delete);
        }
    }
}
