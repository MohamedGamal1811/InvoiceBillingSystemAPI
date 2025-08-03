using FluentValidation;
using InvoiceBillingSystemAPI.Dtos;

namespace InvoiceBillingSystemAPI.Validators
{
    public class CustomerDtoValidator:AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Address).SetValidator(new AddressDtoValidator());
                    
        }
    }
}
