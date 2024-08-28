using MediatR;
using CleanArchitecture.Domain.BuildingBlocks.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.Repositories.Base
{
    public class UnitOfWork(ApplicationDbContext dbContext, IMediator mediator) : IUnitOfWork
    {
        /// <summary>
        /// Asynchronously commits all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            await DispatchDomainEventsAsync();
        }

        #region Private Methods

        private async Task DispatchDomainEventsAsync()
        {
            var domainEventsTasks = new List<Task>();
            var domainEvents = GetAllDomainEvents();

            foreach (var domainEvent in domainEvents)
                domainEventsTasks.Add(mediator.Publish(domainEvent));

            await Task.WhenAll(domainEventsTasks);
            ClearAllDomainEvents();
        }

        private IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = dbContext.ChangeTracker.Entries<IDomainEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
        }

        private void ClearAllDomainEvents()
        {
            var domainEntities = dbContext.ChangeTracker
                .Entries<IDomainEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());
        }

        #endregion
    }
}