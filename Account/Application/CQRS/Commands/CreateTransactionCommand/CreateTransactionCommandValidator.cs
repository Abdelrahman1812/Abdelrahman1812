using FluentValidation;

namespace Account.Application.CQRS.Commands.CreateTransactionCommand
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(p => p.InitialCredit).GreaterThan(0).WithMessage("Invalid Credit Value");
        }
    }
}
