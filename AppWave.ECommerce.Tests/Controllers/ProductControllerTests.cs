using AppWave.ECommerce.API.Controllers;
using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;

namespace AppWave.ECommerce.Tests.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly ProductsController _controller;

    public ProductControllerTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _controller = new ProductsController(_productServiceMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithProducts()
    {
        // Arrange
        var expectedProducts = new PagedResultDto<ProductDto>
        {
            Items = new List<ProductDto>
            {
                new() { Id = Guid.NewGuid(), Name = "Test Product", Price = 99.99m, StockQuantity = 100 }
            },
            TotalCount = 1,
            PageNumber = 1,
            PageSize = 10
        };

        _productServiceMock.Setup(x => x.GetAllAsync(1, 10))
            .ReturnsAsync(expectedProducts);

        // Act
        var result = await _controller.GetProducts(1, 10);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var returnValue = okResult.Value.Should().BeAssignableTo<PagedResultDto<ProductDto>>().Subject;
        returnValue.Should().BeEquivalentTo(expectedProducts);
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WithProduct()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var expectedProduct = new ProductDto
        {
            Id = productId,
            Name = "Test Product",
            Price = 99.99m,
            StockQuantity = 100
        };

        _productServiceMock.Setup(x => x.GetByIdAsync(productId))
            .ReturnsAsync(expectedProduct);

        // Act
        var result = await _controller.GetProduct(productId);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var returnValue = okResult.Value.Should().BeAssignableTo<ProductDto>().Subject;
        returnValue.Should().BeEquivalentTo(expectedProduct);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _productServiceMock.Setup(x => x.GetByIdAsync(productId))
            .ReturnsAsync((ProductDto)null);

        // Act
        var result = await _controller.GetProduct(productId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Create_ReturnsCreatedResult_WithProduct()
    {
        // Arrange
        var createProductDto = new CreateProductDto
        {
            Name = "New Product",
            Description = "Product Description",
            Price = 99.99m,
            StockQuantity = 100
        };

        var createdProduct = new ProductDto
        {
            Id = Guid.NewGuid(),
            Name = "New Product",
            Description = "Product Description",
            Price = 99.99m,
            StockQuantity = 100
        };

        _productServiceMock.Setup(x => x.CreateAsync(createProductDto))
            .ReturnsAsync(createdProduct);

        // Act
        var result = await _controller.CreateProduct(createProductDto);

        // Assert
        var createdResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        var returnValue = createdResult.Value.Should().BeAssignableTo<ProductDto>().Subject;
        returnValue.Should().BeEquivalentTo(createdProduct);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var updateProductDto = new UpdateProductDto
        {
            Name = "Updated Product",
            Description = "Updated Description",
            Price = 89.99m,
            StockQuantity = 50
        };

        var updatedProduct = new ProductDto
        {
            Id = productId,
            Name = "Updated Product",
            Description = "Updated Description",
            Price = 89.99m,
            StockQuantity = 50
        };

        _productServiceMock.Setup(x => x.UpdateAsync(productId, updateProductDto))
            .ReturnsAsync(updatedProduct);

        // Act
        var result = await _controller.UpdateProduct(productId, updateProductDto);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var updateProductDto = new UpdateProductDto
        {
            Name = "Updated Product",
            Description = "Updated Description",
            Price = 89.99m,
            StockQuantity = 50
        };

        _productServiceMock.Setup(x => x.UpdateAsync(productId, updateProductDto))
            .ReturnsAsync((ProductDto)null);

        // Act
        var result = await _controller.UpdateProduct(productId, updateProductDto);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _productServiceMock.Setup(x => x.DeleteAsync(productId))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteProduct(productId);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _productServiceMock.Setup(x => x.DeleteAsync(productId))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteProduct(productId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
} 