using Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace UnitsOfWork
{
    public static class Startup
    {
        public static IServiceCollection AddUnitOfWorkServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkSmartApartment>();
            return services;
        }
    }
}
