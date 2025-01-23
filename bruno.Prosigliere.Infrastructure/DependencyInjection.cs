using bruno.Prosigliere.Domain.Interfaces.Persistence;
using bruno.Prosigliere.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace bruno.Prosigliere.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {      
            services.AddScoped<IBlogPostRepository, FakeBlogPostRepository>();

            return services;    
        }

    }
}
