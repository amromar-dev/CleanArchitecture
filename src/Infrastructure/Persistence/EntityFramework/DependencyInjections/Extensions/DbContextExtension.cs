using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.DependencyInjections.Extensions
{
    public static class DbContextExtension
    {
        /// <summary>
        /// Configure Entity Framework DbContext with SQL Server using the provided connection string
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        internal static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionString)); 
        }

        /// <summary>
        /// Initializes the database by applying any pending migrations to the database.
        /// This method ensures that the database schema is up-to-date with the current model.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> used to configure the application pipeline.</param>
        internal static void MigrateDbContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
