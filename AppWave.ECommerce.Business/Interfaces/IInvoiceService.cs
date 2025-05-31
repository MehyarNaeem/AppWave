using AppWave.ECommerce.Business.DTOs;

namespace AppWave.ECommerce.Business.Interfaces;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
    Task<InvoiceDto> GetInvoiceByIdAsync(Guid id);
    Task<IEnumerable<InvoiceDto>> GetByUserIdAsync(Guid userId);
    Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
    Task<InvoiceDto> UpdateInvoiceAsync(Guid id, UpdateInvoiceDto updateInvoiceDto);
    Task<bool> DeleteInvoiceAsync(Guid id);
} 