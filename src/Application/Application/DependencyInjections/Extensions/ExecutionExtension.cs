using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.BuildingBlocks.Executions;

namespace CleanArchitecture.Application.DependencyInjections.Extensions
{
    public static class ExecutionExtension
    {
        /// <summary>
        /// Configure request execution lifetime DI
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureExecutions(this IServiceCollection services)
        {
            services.AddScoped<IRequestExecution, RequestExecution>();
            services.AddValidatorsFromAssembly(typeof(ExecutionExtension).Assembly);
        }
    }
}
