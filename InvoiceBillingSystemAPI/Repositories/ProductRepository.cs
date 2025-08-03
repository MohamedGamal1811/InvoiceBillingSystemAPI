using InvoiceBillingSystemAPI.Data;
using InvoiceBillingSystemAPI.Interfaces;
using InvoiceBillingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceBillingSystemAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Tag> CreateTagAsync(string name)
        {
            var tag = new Tag { Name = name };
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task DeleteAsync(Product product)
        {
            product.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
            => await _context.Products.Include(p => p.Tags).ToListAsync();


        public async Task<Product> GetByIdAsync(int id)
            => await _context.Products.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
        

        public async Task<Tag?> GetTagByNameAsync(string name) 
            =>  await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
