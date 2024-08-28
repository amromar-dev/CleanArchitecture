using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.SharedKernels.DependencyInjections;
using CleanArchitecture.Application.BuildingBlocks.Contracts.Email.Interfaces;
using CleanArchitecture.Infrastructure.Email.Smtp.Services;
using CleanArchitecture.Infrastructure.Email.Smtp.Configurations;

namespace CleanArchitecture.Infrastructure.Email.Smtp.DependencyInjections
{
    public static class SmtpDependencyInjection
    {
        /// <summary>
        /// Registers the file storage services with the dependency injection container.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSmtp(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, SmtpService>();
            services.Configure<SmtpConfig>();
        }
    }
}
