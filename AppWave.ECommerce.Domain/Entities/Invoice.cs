using AppWave.ECommerce.Domain.Common;

namespace AppWave.ECommerce.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
} 