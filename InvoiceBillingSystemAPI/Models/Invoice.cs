namespace InvoiceBillingSystemAPI.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<InvoiceITem> Items { get; set; } = new List<InvoiceITem>();

        public decimal TotalAmount { get; set; }
        // navigation Property
        public Payment? Payment { get; set; } 

        public bool IsDeleted { get; set; }
    }
}
