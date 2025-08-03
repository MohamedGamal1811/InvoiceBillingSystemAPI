namespace InvoiceBillingSystemAPI.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public AddressDto Address { get; set; } = new();
    }
}
