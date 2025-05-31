using AppWave.ECommerce.Domain.Entities;

namespace AppWave.ECommerce.Domain.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
} 