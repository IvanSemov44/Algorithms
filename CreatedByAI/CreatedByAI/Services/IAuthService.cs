using AICreatedProjectBackend.DTOs;
using AICreatedProjectBackend.Models;

namespace AICreatedProjectBackend.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto> RefreshTokenAsync(string token, string refreshToken);
        Task<bool> RevokeTokenAsync(string token);
        Task<User?> GetUserByIdAsync(int id);
    }
}