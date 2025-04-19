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
    public class TransactionHistoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public TransactionHistoryController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost("CreateTransactionHistory")] 
        public async Task<IActionResult> Create([FromBody] TransactionHistoryForCreationDto historyForCreationDto)
        {
            var rtrt = await _service.TransactionHistoryService.CreateTransactionHistory(historyForCreationDto);
            return Ok();
        }
    }
}
