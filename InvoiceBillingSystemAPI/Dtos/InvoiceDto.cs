namespace InvoiceBillingSystemAPI.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        public List<InvoiceItemDto> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}
