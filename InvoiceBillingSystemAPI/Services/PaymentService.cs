using InvoiceBillingSystemAPI.Dtos;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Mapping;

namespace InvoiceBillingSystemAPI.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _repo;
        private readonly EntityMapper _mapper;

        public PaymentService(IPaymentRepository repo, EntityMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var payments = await _repo.GetAllAsync();
            return payments.Select(_mapper.PaymentToDto).ToList();
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _repo.GetByIdAsync(id);
            return payment is null ? null : _mapper.PaymentToDto(payment);
        }

        public async Task<PaymentDto?> CreateAsync(PaymentDto dto)
        {
            var invoice = await _repo.GetInvoiceByIdAsync(dto.InvoiceId);
            if (invoice is null || invoice.IsDeleted)
                return null;

            var payment = _mapper.PaymentDtoToEntity(dto);
            await _repo.AddAsync(payment);
            return _mapper.PaymentToDto(payment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _repo.GetByIdAsync(id);
            if (payment is null) return false;

            await _repo.DeleteAsync(payment);
            return true;
        }
    }
}
