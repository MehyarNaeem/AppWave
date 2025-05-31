using AppWave.ECommerce.Domain.Common;

namespace AppWave.ECommerce.Domain.Entities
{

    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = "Visitor";
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public string FullName { get; set; }
    }
}