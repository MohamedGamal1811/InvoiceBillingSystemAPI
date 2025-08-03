namespace InvoiceBillingSystemAPI.Models
{
    public class Payment
    {
        public int Id {  get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
        public DateTime PaidAt { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }

    }
}
