using FluentValidation;

namespace Account.Application.CQRS.Queries
{

        public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
        {
            public GetCustomerQueryValidator()
            {
                RuleFor(p => p.CustomerNumber).NotNull().NotEmpty().WithMessage("Customer Number is Required");
            }
        }
    
}
