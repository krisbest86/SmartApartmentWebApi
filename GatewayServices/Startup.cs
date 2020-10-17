using Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServices
{
    public static class Startup
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            
            services.AddScoped<IApiClient, RestApiClient>();
            return services;
        }
    }
}
