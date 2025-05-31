using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Interfaces;
using AppWave.ECommerce.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace AppWave.ECommerce.DataAccess.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice?> GetByIdAsync(Guid id)
        {
            return await _context.Invoices
                .Include(i => i.User)
                .Include(i => i.OrderItems)
                    .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Invoices
                .Include(i => i.User)
                .Include(i => i.OrderItems)
                    .ThenInclude(d => d.Product)
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .Include(i => i.User)
                .Include(i => i.OrderItems)
                    .ThenInclude(d => d.Product)
                .ToListAsync();
        }

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task DeleteAsync(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
} 