namespace CleanArchitecture.Domain.BuildingBlocks.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Asynchronously commits all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}