using InvoiceBillingSystemAPI.Models;

namespace InvoiceBillingSystemAPI.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public DateTime PaidAt { get; set; }
        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }  // ✅ Use Enum
    }
}
