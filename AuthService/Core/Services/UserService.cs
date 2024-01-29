using AuthService.Core.Interfaces;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using AuthService.Core.Helpers;
using Org.BouncyCastle.Security;
using Mysqlx;
using System.Xml.Linq;


namespace AuthService.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserAccountDbContext _userAccountDbContext;
        private readonly JwtTokenHandler _jwtTokenHandler;
        
        public UserService(UserAccountDbContext userAccountDbContext, JwtTokenHandler jwtTokenHandler)
        {

            _userAccountDbContext = userAccountDbContext;
            _jwtTokenHandler = jwtTokenHandler;
        }

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            // Find the user account by email
            var account = await _userAccountDbContext.UserAccount.FirstOrDefaultAsync(c => c.Email == request.Email);

            // Check if the account does not exist
            if (account is null)
            {
                // User not found, return an appropriate response
                return new LoginResponse
                {
                    Message = "Invalid email or password.",
                    Success = false
                };
            }

            // Check if the provided password is correct
            if (!VerifyPassword(account, request.Password))
            {
                // Incorrect password, return an appropriate response
                return new LoginResponse
                {
                    Message = "Invalid email or password.",
                    Success = false
                };
            }

            // Password is correct, generate JWT token
            var authResponse = _jwtTokenHandler.GenerateJwtToken(account);

            // Return a successful login response
            return new LoginResponse
            {
                Name = account.Name,
                Email = account.Email,
                JwtToken = authResponse.JwtToken,
                ExpiresIn = authResponse.ExpiresIn,
                Success = true
            };
        }

        private bool VerifyPassword(UserAccount account, string password)
        {
            // Use the same hashing mechanism as during registration
            string hashedPassword = Salt.ToSha512(password + account.Salt);

            // Compare the hashed password with the stored password
            return hashedPassword == account.Password;
        }

        public async Task<RegistrationResponse?> Register(RegistrationRequest request)
        {
            // Check if the email is already registered
            var account = await _userAccountDbContext.UserAccount.FirstOrDefaultAsync(c => c.Email == request.Email);
          
            if (account is not null)
            {
                // Email is already registered, return an appropriate response
                return new RegistrationResponse
                {
                    Success = false,
                    Message = "Email is already registered."
                };
            }

            // Generate a unique salt for this user
            string salt = Guid.NewGuid().ToString();

            // Create a new user account
            account = new UserAccount()
            {
                Name = request.Name,
                Email = request.Email,
                Phonenumber = request.Phonenumber,
                NationalId = request.NationalId,
                Salt = salt,
                Role = "User",
                Password = Salt.ToSha512(request.Password + salt),
            };

            // Add the user account to the database
            _userAccountDbContext.UserAccount.Add(account);
            await _userAccountDbContext.SaveChangesAsync();

            // Return a successful registration response
            return new RegistrationResponse
            {
                Success = true,
                Message = "Registration successful.",
                UserId = account.Id, // Assuming your UserAccount has an Id property
            };
        }


    }
}
