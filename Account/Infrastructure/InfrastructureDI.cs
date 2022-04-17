using Account.Application.Common.Interfaces;
using Account.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("CustomersDB"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }

    }
}
