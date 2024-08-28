using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Domain.BuildingBlocks.Interfaces;
using CleanArchitecture.Domain.Samples.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.EntityFramework.Repositories;
using CleanArchitecture.Infrastructure.Persistence.EntityFramework.Repositories.Base;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.DependencyInjections.Extensions
{
    public static class RepositoryExtension
    {
        /// <summary>
        /// Extension method to configure repository services in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        internal static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Define repositories
            services.AddScoped<ISampleRepository, SampleRepository>();
        }
    }
}
