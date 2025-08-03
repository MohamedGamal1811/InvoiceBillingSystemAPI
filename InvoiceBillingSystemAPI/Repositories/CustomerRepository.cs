using InvoiceBillingSystemAPI.Data;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceBillingSystemAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _context;
        public CustomerRepository (AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ExistsAsync(int id)=>        
            await _context.Customers.AnyAsync(c => c.Id == id);
        

        public async Task<List<Customer>> GetAllAsync() =>
             await _context.Customers.ToListAsync();
        

        public async Task<Customer> GetByIdAsync(int id) =>
            await _context.Customers.FindAsync(id);
        

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
