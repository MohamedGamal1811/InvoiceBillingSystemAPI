using InvoiceBillingSystemAPI.Dtos;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Mapping;
using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly EntityMapper _mapper;
        public CustomerService(ICustomerRepository repo, EntityMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            return customers.Select(_mapper.CustomerToDto).ToList();
        }
        

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var customer = await _repo.GetByIdAsync(id);
            return customer is null ? null : _mapper.CustomerToDto(customer);
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto dto)
        {
            var entity = _mapper.CustomerDtoToEntity(dto);
            await _repo.AddAsync(entity);
            return _mapper.CustomerToDto(entity);
        }
        public async Task<bool> UpdateAsync(int id, CustomerDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing is null) return false;

            existing.Email = dto.Email;
            existing.Name = dto.Name;
            existing.Address = new Address
            {
                City = dto.Address.City,
                Street = dto.Address.Street,
                ZipCode = dto.Address.ZipCode,
            };
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _repo.GetByIdAsync(id);
            if (customer is null) return false;
            await _repo.DeleteAsync(customer);
            return true;
        }

        public async Task<bool> ExistingAsync(int id)
        {
            return await _repo.ExistsAsync(id);
        }
    }
}
