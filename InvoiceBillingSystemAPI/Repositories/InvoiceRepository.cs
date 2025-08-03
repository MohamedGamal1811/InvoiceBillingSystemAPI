using InvoiceBillingSystemAPI.Data;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceBillingSystemAPI.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllAsync()
            => await _context.Invoices.Include(i=>i.Customer).Include(i=>i.Items).ThenInclude(it=>it.Product).ToListAsync();

        public async Task<Invoice?> GetByIdAsync(int id)
        => await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
                .ThenInclude(it => it.Product)
            .FirstOrDefaultAsync(i => i.Id == id);

        public async Task AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Invoice invoice)
        {
            invoice.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task<Customer?> GetCustomerByIdAsync(int id)
            => await _context.Customers.FindAsync(id);

    }
}
