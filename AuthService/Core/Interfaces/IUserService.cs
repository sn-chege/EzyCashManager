using JwtAuthenticationManager.Models;

namespace AuthService.Core.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse?> Login(LoginRequest request);

        Task<RegistrationResponse?> Register(RegistrationRequest request);
    }
}
