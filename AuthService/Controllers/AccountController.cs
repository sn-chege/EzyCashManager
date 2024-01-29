using AuthService.Core.Interfaces;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task< ActionResult<LoginResponse?>> Authenticate([FromBody] LoginRequest authenticationRequest)
        {
            var authenticationResponse = await _userService.Login(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return Ok(authenticationResponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse?>> Register([FromBody] RegistrationRequest registrationRequest)
        {
            var registrationResponse = await _userService.Register(registrationRequest);
            if(registrationResponse == null) return Unauthorized();
            return Ok(registrationResponse);

        }
    }
}
