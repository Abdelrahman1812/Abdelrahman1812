using Account.Application.Common.Interfaces;
using FluentValidation;

namespace Account.Application.CQRS.Commands.CreateCustomerAccountCommand
{
    public class CreateCustomerAccountCommandValidator : AbstractValidator<CreateCustomerAccountCommand>
    {
        public CreateCustomerAccountCommandValidator()
        {
            RuleFor(p => p.CustomerID).NotNull().NotEmpty().WithMessage("Customer Number is invalid"); 
        }


    }
}
