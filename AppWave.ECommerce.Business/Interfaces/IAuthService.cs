using AppWave.ECommerce.Bus.DTOs;

namespace AppWave.ECommerce.Bus.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
} 