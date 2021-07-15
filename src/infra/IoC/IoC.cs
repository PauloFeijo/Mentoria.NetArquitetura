using Data.Context;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Services;

namespace IoC
{
    public static class IoC
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
            => services
                .ConfigureDatabaseAccess(configuration)
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ICustomerRepository, CustomerRepository>();

        private static IServiceCollection ConfigureDatabaseAccess(this IServiceCollection services, IConfiguration configuration) 
            => services.AddDbContext<Context>(options 
                => options.UseSqlServer(configuration.GetConnectionString("Database")));
    }
}
