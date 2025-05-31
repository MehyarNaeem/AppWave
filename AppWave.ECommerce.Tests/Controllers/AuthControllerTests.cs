using AppWave.ECommerce.API.Controllers;
using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using ECommerceAPI.API.Controllers;

namespace AppWave.ECommerce.Tests.Controllers;

public class AuthControllerTests
{
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _authServiceMock = new Mock<IAuthService>();
        _controller = new AuthController(_authServiceMock.Object);
    }

    [Fact]
    public async Task Register_ReturnsOkResult_WithToken()
    {
        // Arrange
        var registerDto = new RegisterDto
        {
            Email = "test@example.com",
            Password = "TestPassword123!",
            FirstName = "John",
            LastName = "Doe"
        };

        var expectedResponse = new AuthResponseDto
        {
            IsSuccess = true,
            Token = "test_token",
            User = new UserDto
            {
                Id = 1,
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Role = "User"
            }
        };

        _authServiceMock.Setup(x => x.RegisterAsync(registerDto))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Register(registerDto);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var returnValue = okResult.Value.Should().BeAssignableTo<AuthResponseDto>().Subject;
        returnValue.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_WhenRegistrationFails()
    {
        // Arrange
        var registerDto = new RegisterDto
        {
            Email = "test@example.com",
            Password = "TestPassword123!",
            FirstName = "John",
            LastName = "Doe"
        };

        var expectedResponse = new AuthResponseDto
        {
            IsSuccess = false,
            Message = "Email already exists"
        };

        _authServiceMock.Setup(x => x.RegisterAsync(registerDto))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Register(registerDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var returnValue = badRequestResult.Value.Should().BeAssignableTo<AuthResponseDto>().Subject;
        returnValue.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Login_ReturnsOkResult_WithToken()
    {
        // Arrange
        var loginDto = new LoginDto
        {
            Email = "test@example.com",
            Password = "TestPassword123!"
        };

        var expectedResponse = new AuthResponseDto
        {
            IsSuccess = true,
            Token = "test_token",
            User = new UserDto
            {
                Id = 1,
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Role = "User"
            }
        };

        _authServiceMock.Setup(x => x.LoginAsync(loginDto))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Login(loginDto);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var returnValue = okResult.Value.Should().BeAssignableTo<AuthResponseDto>().Subject;
        returnValue.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Login_ReturnsBadRequest_WhenLoginFails()
    {
        // Arrange
        var loginDto = new LoginDto
        {
            Email = "test@example.com",
            Password = "WrongPassword123!"
        };

        var expectedResponse = new AuthResponseDto
        {
            IsSuccess = false,
            Message = "Invalid credentials"
        };

        _authServiceMock.Setup(x => x.LoginAsync(loginDto))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Login(loginDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var returnValue = badRequestResult.Value.Should().BeAssignableTo<AuthResponseDto>().Subject;
        returnValue.Should().BeEquivalentTo(expectedResponse);
    }
} 