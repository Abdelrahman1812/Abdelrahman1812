using Microsoft.EntityFrameworkCore;
using Account.Models.Domain.Entities;

namespace Account.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAccount> CustomerAccounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
