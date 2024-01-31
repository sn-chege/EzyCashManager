using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly UserAccountDbContext _dbContext;

        public AccountController(JwtTokenHandler jwtTokenHandler, UserAccountDbContext dbContext)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _dbContext = dbContext;
        }

        [HttpPost("generate-token")]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return authenticationResponse;
        }

        [HttpPost("register")]
        public ActionResult<UserAccount> Register([FromBody] UserAccount userAccount)
        {
            try
            {
                _dbContext.UserAccounts.Add(userAccount);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(Register), userAccount);
            }
            catch (Exception ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserAccount>> GetUsers()
        {
            try
            {
                // Retrieve all users from the database
                var users = _dbContext.UserAccounts.ToList();

                // You may choose to return the list of users or customize the response as needed
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve users: {ex.Message}");
            }
        }
    }
}
