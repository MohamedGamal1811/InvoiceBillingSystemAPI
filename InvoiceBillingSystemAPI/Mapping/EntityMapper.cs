using InvoiceBillingSystemAPI.Dtos;
using InvoiceBillingSystemAPI.Models;
using Riok.Mapperly.Abstractions;

namespace InvoiceBillingSystemAPI.Mapping
{
    [Mapper]
    public partial class EntityMapper
    {
        public partial CustomerDto CustomerToDto(Customer customer);
        public partial Customer CustomerDtoToEntity(CustomerDto customerDto);

        public partial ProductDto ProductToDto(Product product);
        public partial Product ProductDtoToEntity(ProductDto dto);

        public partial InvoiceDto InvoiceToDto(Invoice invoice);
        [MapProperty(nameof(InvoiceDto.Items), nameof(Invoice.Items))]
        public partial Invoice InvoiceDtoToIEntity(InvoiceDto dto);

        public partial PaymentDto PaymentToDto(Payment payment);
        public partial Payment PaymentDtoToEntity(PaymentDto dto);
        

    }
}
