using FluentValidation;
using InvoiceBillingSystemAPI.Dtos;

namespace InvoiceBillingSystemAPI.Validators
{
    public class AddressDtoValidator:AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x=> x.Street).NotEmpty();
            RuleFor(x=> x.City).NotEmpty();
            RuleFor(x=> x.ZipCode).NotEmpty();
        }
    }
}
