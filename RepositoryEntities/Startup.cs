using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class Startup
    {
        public static IServiceCollection AddSmartApartmentDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmartApartmentContext>(options =>
                options.UseSqlServer(configuration["DbConnection"]));

            return services;
        }
    }
}
