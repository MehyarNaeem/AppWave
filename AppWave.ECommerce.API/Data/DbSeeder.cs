using AppWave.ECommerce.DataAccess.Data;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AppWave.ECommerce.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                // Create admin user
                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = "Admin User",
                    Email = "admin@example.com",
                    PasswordHash = HashPassword("Admin123!"),
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow
                };

                // Create regular user
                var regularUser = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = "Regular User",
                    Email = "user@example.com",
                    PasswordHash = HashPassword("User123!"),
                    Role = "Visitor",
                    CreatedAt = DateTime.UtcNow
                };

                await context.Users.AddRangeAsync(adminUser, regularUser);
                await context.SaveChangesAsync();
            }

            if (!await context.Products.AnyAsync())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "لابتوب",
                        EnglishName = "Laptop",
                        Price = 999.99m,
                        StockQuantity = 10,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "هاتف ذكي",
                        EnglishName = "Smartphone",
                        Price = 499.99m,
                        StockQuantity = 15,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "سماعات",
                        EnglishName = "Headphones",
                        Price = 99.99m,
                        StockQuantity = 20,
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 