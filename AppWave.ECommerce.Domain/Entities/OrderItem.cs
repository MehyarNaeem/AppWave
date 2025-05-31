using ECommerceAPI.Domain.Common;

namespace ECommerceAPI.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public decimal Price { get; set; }
} 