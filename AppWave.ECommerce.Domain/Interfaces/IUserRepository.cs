using AppWave.ECommerce.Domain.Entities;

namespace AppWave.ECommerce.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
} 