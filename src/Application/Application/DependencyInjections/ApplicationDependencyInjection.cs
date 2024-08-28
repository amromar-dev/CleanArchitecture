using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.DependencyInjections.Extensions;

namespace CleanArchitecture.Application.DependencyInjections
{
    public static class ApplicationDependencyInjection
    {
        /// <summary>
        /// Configure application services lifetime DI
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.ConfigureMediatR();
            services.ConfigureAutoMapper();
            services.ConfigureExecutions();
        }
    }
}