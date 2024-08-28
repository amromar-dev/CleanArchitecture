using Microsoft.OpenApi.Models;
using CleanArchitecture.API.DependencyInjections.Extensions;

namespace CleanArchitecture.API.DependencyInjections
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Add Swagger (OpenAPI) documentation configurations
        /// </summary>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // Include Areas
                foreach (var area in AreaExtension.GetAreas())
                    c.SwaggerDoc(area, new OpenApiInfo { Title = $"{area} API", Version = "v1" });

                c.TagActionsBy(api => new List<string> { $"{api.ActionDescriptor.RouteValues["controller"]}" ?? "Default" });
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var area = $"{apiDesc.ActionDescriptor.RouteValues["area"]}";
                    return !string.IsNullOrEmpty(area) && docName.Equals(area, StringComparison.OrdinalIgnoreCase);
                });

                // Include XML comments if you have them.
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: false);
            });
        }

        /// <summary>
        /// Use Swagger Middleware Injection
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwagger(this WebApplication app)
        {
            if (app.Environment.IsProduction())
                return;

            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI(c =>
            {
                // Add Swagger UI endpoints for each controller
                foreach (var area in AreaExtension.GetAreas())
                    c.SwaggerEndpoint($"/swagger/{area}/swagger.json", $"{area} API V1");
            });
        }
    }
}
