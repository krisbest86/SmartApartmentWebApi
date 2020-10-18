using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
