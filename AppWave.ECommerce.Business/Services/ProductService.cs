
using AppWave.ECommerce.Business.DTOs;
using AppWave.ECommerce.Business.Interfaces;
using AutoMapper;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AppWave.ECommerce.Business.Services
{
    public class ProductService : IProductService                    
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            return await CreateAsync(createProductDto);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateProductDto)
        {
            return await UpdateAsync(id, updateProductDto);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<PagedResultDto<ProductDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var products = await _productRepository.GetAllAsync();
            var totalCount = products.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            
            var pagedProducts = products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return new PagedResultDto<ProductDto>
            {
                Items = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return null;

            _mapper.Map(updateProductDto, product);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;

            await _productRepository.DeleteAsync(id);
            return true;
        }

        
    }
} 