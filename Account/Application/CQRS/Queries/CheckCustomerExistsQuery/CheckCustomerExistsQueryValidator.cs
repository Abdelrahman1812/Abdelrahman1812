using FluentValidation;

namespace Account.Application.CQRS.Queries
{
    public class CheckCustomerExistsQueryValidator : AbstractValidator<CheckCustomerExistsQuery>
    {
        public CheckCustomerExistsQueryValidator()
        {
            RuleFor(p => p.CustomerNumber).NotNull().NotEmpty().WithMessage("Customer Number is invalid");
        }
    }
}
