using Microsoft.Extensions.DependencyInjection;
using PaymentProcessor.Application.Payments;
using PaymentProcessor.Application.Shared.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPaymentService), typeof(PaymentService));

            return services;
        }
    }
}
