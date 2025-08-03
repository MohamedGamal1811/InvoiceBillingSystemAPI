namespace InvoiceBillingSystemAPI.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}
