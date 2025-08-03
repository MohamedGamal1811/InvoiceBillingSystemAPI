using InvoiceBillingSystemAPI.Data;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceBillingSystemAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
            => await _context.Payments.Include(p => p.Invoice).ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id)
            => await _context.Payments.Include(p => p.Invoice).FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Payment payment)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int invoiceId)
            => await _context.Invoices.FindAsync(invoiceId);
    }
}
