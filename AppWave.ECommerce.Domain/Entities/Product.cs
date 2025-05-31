using AppWave.ECommerce.Domain.Common;

namespace AppWave.ECommerce.Domain.Entities
{

    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public string EnglishName { get; set; } = null!;
    }
} 