using Account.Application.Common.Interfaces;
using Account.Application.CQRS.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Account.Application.CQRS.Queries
{
    public class CheckCustomerExistsQuery : IRequest<Tuple<bool , Guid>>
    {
        public string CustomerNumber { get; set; }
    }

    public class CheckCustomerExistsQueryHandler : IRequestHandler<CheckCustomerExistsQuery, Tuple<bool, Guid>>
    {
        private readonly IApplicationDbContext _context;
        public CheckCustomerExistsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tuple<bool, Guid>> Handle(CheckCustomerExistsQuery request, CancellationToken cancellationToken)
        {
            // here we may get data with stored procedure or using ado.net 
            var customer = await _context.Customers.SingleOrDefaultAsync(p => p.CustomerNumber == request.CustomerNumber);
            if (customer == null)  return Tuple.Create(false , Guid.Empty);

            return Tuple.Create(true, customer.ID);
        }
    }


}
