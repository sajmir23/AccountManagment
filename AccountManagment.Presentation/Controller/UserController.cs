
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
    public class UserController:ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public UserController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAll(bool trackChanges)
        {
            var user = await _service.UserService.GetAll(trackChanges);
            return Ok(user);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int Id,bool trackChanges)
        {
            var user = await _service.UserService.GetUser(Id,trackChanges);
            return Ok(user);
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto userForCreation)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _service.UserService.Create(userForCreation);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserForUpdateDto userForUpdate,int Id)
        {
            var user = await _service.UserService.Update(userForUpdate,Id);
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _service.UserService.Delete(Id);
            return Ok();
        }

    }
}

