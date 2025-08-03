namespace InvoiceBillingSystemAPI.Models
{
    // like laptops , iPhone 
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
