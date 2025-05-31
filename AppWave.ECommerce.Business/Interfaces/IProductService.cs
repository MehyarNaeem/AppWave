using AppWave.ECommerce.Bus.DTOs;
using AppWave.ECommerce.Bus.Interfaces;
using AppWave.ECommerce.Business.DTOs;

namespace AppWave.ECommerce.Bus.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<PagedResultDto<ProductDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<ProductDto> CreateAsync(CreateProductDto createProductDto);
    Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto updateProductDto);
    Task<bool> DeleteAsync(Guid id);
} 