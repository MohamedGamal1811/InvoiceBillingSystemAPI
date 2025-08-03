using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Payment payment);
        Task<Invoice?> GetInvoiceByIdAsync(int invoiceId);
    }
}
