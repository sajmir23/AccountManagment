using Microsoft.AspNetCore.Authentication;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var new_user = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);
            if (!new_user.Succeeded)
            {
                foreach (var error in new_user.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> ValidateUserAndCreateToken(UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
            return Unauthorized();

           // var tokendto = await _service.AuthenticationService.CreateToken(populateExp:true);
            return 
          Ok(new 
            {
                Token= await _service.AuthenticationService.CreateToken()
            }
          );
        }
    }
}
