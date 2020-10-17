using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryServices
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmartApartmentContext>(options =>
                options.UseSqlServer(configuration["DbConnection"]));

            return services;
        }
    }
}
