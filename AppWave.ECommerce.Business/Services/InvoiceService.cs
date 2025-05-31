using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using AutoMapper;
using AppWave.ECommerce.Domain.Entities;
using AppWave.ECommerce.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AppWave.ECommerce.Business.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public InvoiceService(
        IInvoiceRepository invoiceRepository,
        IProductRepository productRepository,
        IMapper mapper,
        IConfiguration configuration)
    {
        _invoiceRepository = invoiceRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(Guid id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<IEnumerable<InvoiceDto>> GetByUserIdAsync(Guid userId)
    {
        var invoices = await _invoiceRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
    }

    public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
    {
        var invoice = _mapper.Map<Invoice>(createInvoiceDto);
        await _invoiceRepository.AddAsync(invoice);
        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<InvoiceDto> UpdateInvoiceAsync(Guid id, UpdateInvoiceDto updateInvoiceDto)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        if (invoice == null)
            return null;

        _mapper.Map(updateInvoiceDto, invoice);
        await _invoiceRepository.UpdateAsync(invoice);
        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<bool> DeleteInvoiceAsync(Guid id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        if (invoice == null)
            return false;

        await _invoiceRepository.DeleteAsync(invoice);
        return true;
    }
} 