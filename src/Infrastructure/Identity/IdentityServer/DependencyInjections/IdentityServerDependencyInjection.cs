using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.BuildingBlocks.Contracts.Identity;
using CleanArchitecture.Infrastructure.Identity.IdentityServer.Configurations;
using CleanArchitecture.SharedKernels.DependencyInjections;

namespace CleanArchitecture.Infrastructure.Identity.IdentityServer.DependencyInjections
{
    public static class IdentityServerDependencyInjection
    {
        /// <summary>
        /// Configures the Identity Server services.
        /// </summary>
        public static void ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.Configure<IdentityConfig>(out var config);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = configuration.GetValue<string>(config.Authority);
                options.Audience = configuration.GetValue<string>(config.Audience);
            });
        }
    }
}
