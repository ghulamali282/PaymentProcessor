using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentProcessor.Domain.Repository;
using PaymentProcessor.Infrastructer.Repository;

namespace PaymentProcessor.Infrastructer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentProcessorDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
