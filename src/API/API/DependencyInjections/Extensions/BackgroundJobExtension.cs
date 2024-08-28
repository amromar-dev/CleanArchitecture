using CleanArchitecture.Application.BackgroundJobs;
using CleanArchitecture.Application.BuildingBlocks.Contracts.Scheduler.Interfaces;
using CleanArchitecture.Application.BuildingBlocks.Contracts.Scheduler.Models;

namespace CleanArchitecture.API.DependencyInjections
{
    /// <summary>
    /// 
    /// </summary>
    public static class BackgroundJobExtension
    {
        /// <summary>
        /// Adds or updates a recurring job using the specified recurring expression.
        /// </summary>
        public static void InitializeBackgroundJobs(this IApplicationBuilder app)
        {
            app.AddOrUpdate<DeactiveExpiredSampleBackgroundJob>(RecurringExpression.MinuteInterval(3));
        }

        #region Private Methods
       
        private static void AddOrUpdate<T>(this IApplicationBuilder app, RecurringExpression recurringExpression) where T : class, IRecurringJob
        {
            var scope = app.ApplicationServices.CreateScope();
            var scheduler = scope.ServiceProvider.GetRequiredService<IScheduler>();

            scheduler.Recurring<T>(typeof(T).Name, recurringExpression);
        } 

        #endregion
    }
}
