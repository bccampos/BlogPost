
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;
using System.Reflection;

namespace bruno.Prosigliere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddScoped<IMapper, Mapper>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }

    }
}
