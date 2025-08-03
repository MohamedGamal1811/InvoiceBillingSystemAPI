using InvoiceBillingSystemAPI.Dtos;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Mapping;
using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Services
{
    public class InvoiceService
    {

        private readonly IInvoiceRepository _repo;
        private readonly EntityMapper _mapper;

        public InvoiceService(IInvoiceRepository repo, EntityMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _repo.GetAllAsync();
            return invoices.Select(_mapper.InvoiceToDto).ToList();
        }

        public async Task<InvoiceDto?> GetByIdAsync(int id)
        {
            var invoice = await _repo.GetByIdAsync(id);
            return invoice is null ? null : _mapper.InvoiceToDto(invoice);
        }

        public async Task<InvoiceDto?> CreateAsync(InvoiceDto dto)
        {
            var customer = await _repo.GetCustomerByIdAsync(dto.CustomerId);
            if (customer is null) return null;

            var items = new List<InvoiceITem>();
            decimal total = 0;

            foreach (var itemDto in dto.Items)
            {
                var product = await _repo.GetProductByIdAsync(itemDto.ProductId);
                if (product is null) continue;

                var invoiceItem = new InvoiceITem
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    UnitPrice = itemDto.UnitPrice
                };

                total += invoiceItem.UnitPrice * invoiceItem.Quantity;
                items.Add(invoiceItem);
            }

            var invoice = new Invoice
            {
                CustomerId = dto.CustomerId,
                Items = items,
                TotalAmount = total
            };

            await _repo.AddAsync(invoice);
            return _mapper.InvoiceToDto(invoice);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var invoice = await _repo.GetByIdAsync(id);
            if (invoice is null) return false;

            await _repo.DeleteAsync(invoice);
            return true;
        }
    }
}
