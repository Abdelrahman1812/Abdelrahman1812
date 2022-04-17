using Account.Application.Common.Interfaces;
using Account.Application.CQRS.Common.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.CQRS.Queries
{
    public class GetCustomerQuery : IRequest<CustomerDTO>
    {
        public string CustomerNumber { get; set; }
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly IApplicationDbContext _context;    
        public GetCustomerQueryHandler(IApplicationDbContext context )
        {
            _context = context;
        }
        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            // here we may get data with stored procedure or using ado.net 
            var customer = await _context.Customers.SingleOrDefaultAsync(p=>p.CustomerNumber == request.CustomerNumber);
            if (customer == null) throw new NotFoundException("Customer Not Found");

            
            return new CustomerDTO() { Id = customer.ID , CustomerNumber = customer.CustomerNumber , Name = customer.Name , SurName = customer.SurName};
        }
    }


}
