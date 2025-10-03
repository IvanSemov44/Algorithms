using AICreatedProjectBackend.Data;
using AICreatedProjectBackend.DTOs;
using AICreatedProjectBackend.Helpers;
using AICreatedProjectBackend.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AICreatedProjectBackend.Tests
{
    public class AuthServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            var jwtSettings = new JwtSettings
            {
                Secret = "test-secret-key-that-is-long-enough",
                Issuer = "test",
                Audience = "test",
                TokenExpirationInMinutes = 60,
                RefreshTokenExpirationInDays = 7
            };

            _authService = new AuthService(_context, jwtSettings);
        }

        [Fact]
        public async Task Register_ValidUser_ReturnsAuthResponse()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Email = "test@example.com",
                Password = "Password123!",
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            var result = await _authService.RegisterAsync(registerDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Token);
            Assert.NotNull(result.RefreshToken);
            Assert.Equal(registerDto.Email, result.User.Email);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsAuthResponse()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Email = "test@example.com",
                Password = "Password123!",
                FirstName = "John",
                LastName = "Doe"
            };
            await _authService.RegisterAsync(registerDto);

            var loginDto = new LoginDto
            {
                Email = "test@example.com",
                Password = "Password123!"
            };

            // Act
            var result = await _authService.LoginAsync(loginDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Token);
            Assert.NotNull(result.RefreshToken);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ThrowsException()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "nonexistent@example.com",
                Password = "WrongPassword"
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.LoginAsync(loginDto));
        }
        [Fact]
        public void Test1_ShouldPass()
        {
            Assert.True(1 + 1 == 2);
        }
    }
}