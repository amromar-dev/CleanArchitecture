using CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage.Configurations;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.BuildingBlocks.Contracts.FileStorage.Interfaces;
using CleanArchitecture.SharedKernels.DependencyInjections;

namespace CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage.DependencyInjections
{
    public static class FileLocalStorageDependencyInjection
    {
        /// <summary>
        /// Registers the file storage services with the dependency injection container.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureFileLocalStorage(this IServiceCollection services)
        {
            services.AddScoped<IFileStorage, FileLocalStorageService>();
            services.Configure<FileLocalStorageConfig>();
        }
    }
}
