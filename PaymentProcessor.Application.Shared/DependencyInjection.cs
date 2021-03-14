using Microsoft.Extensions.DependencyInjection;
using PaymentProcessor.Application.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterAllTransientTypes<T>(this IServiceCollection services, Assembly[] assemblies,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
            var typesFromAssemwblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x =>typeof(T).IsAssignableFrom(typeof(ITransientDependency))));

            foreach (var type in typesFromAssemblies)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            }

            return services;
        }
    }
}
