using CleanArchitecture.SharedKernels.Environments;

namespace CleanArchitecture.API.DependencyInjections
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnvironmentExtension
    {
        /// <summary>
        /// Add default supported localization and culture for the application
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAppEnvironment(this IServiceCollection services)
        {
            var hostEnvironment = services.BuildServiceProvider().GetService<IWebHostEnvironment>();
            Enum.TryParse<ApplicationEnvironmentType>(hostEnvironment?.EnvironmentName, true, out var environmentType);

            ApplicationEnvironment.CurrentEnvironment = environmentType;
        }
    }
}
