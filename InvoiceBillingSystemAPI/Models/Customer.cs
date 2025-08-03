namespace InvoiceBillingSystemAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Address Address { get; set; } = new Address();
        public bool IsDeleted { get; set; }= false;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
