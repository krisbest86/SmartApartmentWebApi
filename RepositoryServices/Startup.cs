using Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryServices
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
