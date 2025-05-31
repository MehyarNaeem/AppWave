using AppWave.ECommerce.Domain.Entities;

namespace AppWave.ECommerce.Domain.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    Task UpdateAsync(Product product);
} 