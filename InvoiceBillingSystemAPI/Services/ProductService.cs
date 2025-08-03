using InvoiceBillingSystemAPI.Dtos;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Mapping;
using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Services
{
    public class ProductService
    {
        IProductRepository _repository;
        private readonly EntityMapper _mapper;
        public ProductService(IProductRepository repository,EntityMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync(); 
            return products.Select(_mapper.ProductToDto).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product is null ? null : _mapper.ProductToDto(product);
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var entity = new Product
            {
                Name = dto.Name,
                UnitPrice = dto.UnitPrice,
            };

            // Handle tag mapping manually
            foreach (var tagName in dto.Tags)
            {
                var existingTag = await _repository.GetTagByNameAsync(tagName);
                if (existingTag != null)
                    entity.Tags.Add(existingTag);
                
                else
                {
                    var newTag = await _repository.CreateTagAsync(tagName);
                    entity.Tags.Add(newTag);
                }

            }
            await _repository.AddAsync(entity);
            return _mapper.ProductToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product is null) return false;
            product.Name = dto.Name;
            product.UnitPrice = dto.UnitPrice;
            // Update tags
            product.Tags.Clear();
            foreach (var tagName in dto.Tags)
            {
                var tag = await _repository.GetTagByNameAsync(tagName) ?? await _repository.CreateTagAsync(tagName);
                product.Tags.Add(tag);
            }

            await _repository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product is null) return false;
            await _repository.DeleteAsync(product);
            return true;
        }


    }
}
