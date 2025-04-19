using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.Dto;
using Shared.RequstParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagment.Presentation.Controller
{
    [Route("api/controller")]
    [ApiController]
    public class BankTransactionsController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public BankTransactionsController(IServiceManager service,ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }
       // [Authorize(Roles ="Manager")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTransactions(bool trackChanges)
        {
            var transaction = await _service.BankTransactionsService.GetBankTransactions(trackChanges);
          
            var baseresponse = new BaseResponse<object, object>
            {
                Result = true,
                Error = "",
                Data = transaction,
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseresponse);
        }
        //[Authorize]
        [HttpGet("GetTransaction")]
        
        public async Task<IActionResult> GetTransaction(int Id ,bool trackChanges)
        {
            var transaction = await _service.BankTransactionsService.GetBankTransaction(Id , trackChanges);

            var baseresponse = new BaseResponse<BankTransactionsDto, object>
            {
                Result = true,
                Error = "",
                Data = transaction,
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseresponse);
        }
        //[Authorize]
        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] BankTransactionForCreationDto bankTransactionsDto,int AccountId)
        {
            try
            {
                if (bankTransactionsDto is null)
                {
                    return BadRequest("bankTransactionsDto object is null.");
                }

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var transaction = await _service.BankTransactionsService.CreateRecord(bankTransactionsDto,AccountId);

                
                var baseresponse = new BaseResponse<object, object>
                {
                    Result = true,
                    Error = "",
                    Data = transaction,
                    StatusCode = StatusCodes.Status200OK
                };
                
                if (!transaction)
                    return BadRequest("Transaksioni deshtoi." +
                        "Vlera e terheqjes eshte me e madhe sesa balanca aktuale.");
                return Ok(baseresponse);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"An error occured.{ex.Message}");
                throw; 
            }
        }
        /*
        //[Authorize]
        [HttpPut("UpdateTransactions")]
        public async Task<IActionResult> UpdateTransaction([FromBody] BankTransactionsDto bankTransactionsDto,int Id)
        {
            if (bankTransactionsDto is null)
            {
                return BadRequest("bankTransactionsDto object is null.");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var transaction = await _service.BankTransactionsService.UpdateRecord(bankTransactionsDto, Id);

            var baseresponse = new BaseResponse<object, object>
            {
                Result = true,
                Error = "",
                Data = transaction,
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseresponse);
        }
        */
        //[Authorize]
        [HttpDelete("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(int AccountId,int TransactionId)
        {
            var transaction = await _service.BankTransactionsService.Delete(AccountId,TransactionId);

            var baseresponse = new BaseResponse<object, object>
            {
                Result = true,
                Error = "",
                Data = transaction,
                StatusCode = StatusCodes.Status200OK
            };
            return Ok(baseresponse);
        }
    }
}
