using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using AppWave.ECommerce.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AppWave.ECommerce.Infrastructure.Services;

public class AuthService : IAuthService

{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto regDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(regDto.Email);
        if (existingUser != null)
        {
            return new AuthResponseDto { IsSuccess=false,Message= "User with this email already exists" };
        }

        var user = new Domain.Entities.User
        {
            Email = regDto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(regDto.Password),
            FirstName = regDto.FirstName,
            LastName = regDto.LastName,
            PhoneNumber = regDto.PhoneNumber,
            Role = "Customer",
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
        return new AuthResponseDto { IsSuccess = true, Message = "User registered successfully\"" };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return new AuthResponseDto { IsSuccess=false,Message="Email address not found" };
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return new AuthResponseDto { IsSuccess = false, Message = "Invalid password" };
        }

        var token = GenerateJwtToken(user);
        return new AuthResponseDto { IsSuccess = true, Token = token};
        
    }

    private string GenerateJwtToken(Domain.Entities.User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found")));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
} 