using Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace UnitsOfWork
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkSmartApartment>();
            return services;
        }
    }
}
