using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public ClientController(IServiceManager service,ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }
        //[Authorize]
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllCleints(bool trackChanges)
        {
            var client = await _service.ClientsService.GetAll(trackChanges:true); 
            return Ok(client);
        }
        //[Authorize]
        [HttpGet("GetClient")]
        public async Task<IActionResult> GetClient(int Id,bool trackChanges)
        {
            var client=await _service.ClientsService.GetClient(Id,trackChanges);

            if(client == null)
                return NotFound($"Klienti me Id={Id} nuk u gjet.");

            return Ok(client);
        }
        //[Authorize]
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] ClientForCreationDto client)
        {
            if (client == null)
                return BadRequest("Të dhënat e klientit nuk janë të sakta.");

            await _service.ClientsService.Create(client);

            return Ok();
        }

        //[Authorize]
        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientForUpdateDto client,int Id)
        {
            await _service.ClientsService.Update(client, Id);
            return Ok();
        }

        //[Authorize]
        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int Id)
        {
            await _service.ClientsService.Delete(Id);
            return Ok();
        }
    }
}
