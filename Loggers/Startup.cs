using Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Loggers
{
    public static class Startup
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            services.AddSingleton<ILog, ConsoleLogger>();
            return services;
        }
    }
}
