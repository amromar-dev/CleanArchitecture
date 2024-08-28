using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CleanArchitecture.API.DependencyInjections
{
    /// <summary>
    /// 
    /// </summary>
    public static class APIDependencyInjection
    {
        /// <summary>
        /// Extension method for configuring API-related services in the application.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAPIServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = false);

            services.AddHttpClient();
            services.AddHttpContextAccessor();

            services.ConfigureAppEnvironment();
            services.ConfigureSwagger();
            services.ConfigureCorsPolicy();
            services.ConfigureLocalizations();
        }
    }
}
