using CleanArchitecture.Infrastructure.Persistence.EntityFramework.DependencyInjections;
using CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage.DependencyInjections;
using CleanArchitecture.Infrastructure.Email.Smtp.DependencyInjections;
using CleanArchitecture.Infrastructure.Scheduler.Hangfire.DependencyInjections;
using CleanArchitecture.Infrastructure.Identity.IdentityServer.DependencyInjections;

namespace CleanArchitecture.API.DependencyInjections
{
    /// <summary>
    /// 
    /// </summary>
    public static class InfrastructureExtension
    {
        /// <summary>
        /// Extension method for configuring the infrastructure services in the application.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureEntityFramework(configuration);
            services.ConfigureIdentityServer(configuration);
            services.ConfigureHangfire(configuration);
            services.ConfigureFileLocalStorage();
            services.ConfigureSmtp();
        }

        /// <summary>
        /// Extension method for initializing the infrastructure components of the application.
        /// </summary>
        /// <param name="app"></param>
        public static void InitializeInfrastructure(this IApplicationBuilder app)
        {
            app.InitializeEntityFramework();
            app.UseHangFire();
        }
    }
}
