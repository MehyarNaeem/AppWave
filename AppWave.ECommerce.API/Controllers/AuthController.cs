using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppWave.ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var authResponseDto = await _authService.RegisterAsync(registerDto);
            if (!string.IsNullOrEmpty(authResponseDto.Message))
            {
                return BadRequest(authResponseDto.Message);
            }

            return Ok(authResponseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var authResponseDto = await _authService.LoginAsync(loginDto);
            if (!authResponseDto.IsSuccess)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(authResponseDto);
        }
    }
} 