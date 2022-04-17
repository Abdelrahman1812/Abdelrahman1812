
using Account.Application.Common.Interfaces;
using MediatR;

namespace Account.Application.CQRS.Commands.CreateCustomerAccountCommand
{
    public class CreateCustomerAccountCommand : IRequest<int>
    {
        public Guid CustomerID { get; set; }
    }


    public class CreateCustomerAccountCommandHandler : IRequestHandler<CreateCustomerAccountCommand, int>
    {
        public readonly IApplicationDbContext _context;
        public CreateCustomerAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
        {
            var CustomerAccount = new Models.Domain.Entities.CustomerAccount() { CustomerID = request.CustomerID };

           await  _context.CustomerAccounts.AddAsync(CustomerAccount, cancellationToken);

           var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0 ? CustomerAccount.AccountNumber : 0;

        }
    }


}
