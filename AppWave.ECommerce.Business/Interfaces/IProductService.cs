using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;


namespace AppWave.ECommerce.Business.Interfaces;

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