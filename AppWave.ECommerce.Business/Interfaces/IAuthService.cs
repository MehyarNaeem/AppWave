using AppWave.ECommerce.Business.DTOs;

namespace AppWave.ECommerce.Business.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
} 