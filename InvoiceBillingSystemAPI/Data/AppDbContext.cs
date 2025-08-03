using InvoiceBillingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceBillingSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceITem> InvoiceItems => Set<InvoiceITem>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1️⃣ Configure Address as an Owned Type
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
            // 2️⃣ Add Global Filter for Soft Delete
            modelBuilder.Entity<Customer>().HasQueryFilter(c=> !c.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            // 3️⃣ Configure Many-to-Many (Product ↔ Tag)
            modelBuilder.Entity<Product>().HasMany(p => p.Tags).WithMany(t => t.Products).UsingEntity(j => j.ToTable("ProductTags"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
