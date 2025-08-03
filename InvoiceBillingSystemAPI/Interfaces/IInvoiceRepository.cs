using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(Invoice invoice);

        Task<Product?> GetProductByIdAsync(int id);
        Task<Customer?> GetCustomerByIdAsync(int id);
    }
}
