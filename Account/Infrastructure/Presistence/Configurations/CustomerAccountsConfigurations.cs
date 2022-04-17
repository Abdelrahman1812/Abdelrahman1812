using Account.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Account.Infrastructure.Presistence.Configurations
{

    public class CustomerAccountsConfigurations : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(t => new { t.ID, t.AccountNumber });

            builder.Property(t => t.ID).HasValueGenerator<GuidValueGenerator>();
            builder.Property(t => t.AccountNumber).ValueGeneratedOnAdd();
        }
    }
}
