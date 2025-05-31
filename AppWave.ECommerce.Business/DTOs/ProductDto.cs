namespace AppWave.ECommerce.Bus.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; } = null!;
        public string EnglishName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; } = null!;
        public string EnglishName { get; set; } = null!;
    }

    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public string? EnglishName { get; set; }
    }
} 