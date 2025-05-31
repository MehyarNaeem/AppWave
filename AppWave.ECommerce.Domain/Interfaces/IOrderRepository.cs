using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Domain.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
} 