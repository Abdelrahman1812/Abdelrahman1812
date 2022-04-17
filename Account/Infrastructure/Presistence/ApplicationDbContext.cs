using Account.Application.Common.Interfaces;
using Account.Models.Domain.Common;
using Account.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Account.Infrastructure.Presistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            SeedDummyCustomers();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get ; set ; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

          
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task SeedDummyCustomers()
        {
            // Seed, if necessary
            if (!Customers.Any())
            {
                Customers.Add(new Customer()
                {
                    Name = "Test",
                    CustomerNumber = "123",
                    ID = Guid.NewGuid(),
                    SurName = "T-Customer"
                });
                Customers.Add(new Customer()
                {
                    Name = "Abdelrahman",
                    CustomerNumber = "456",
                    ID = Guid.NewGuid(),
                    SurName = "Ewies"
                });
                Customers.Add(new Customer()
                {
                    Name = "Blue Harvest",
                    CustomerNumber = "789",
                    ID = Guid.NewGuid(),
                    SurName = "BH"
                });

                await SaveChangesAsync();
            }
        }


    }



}
