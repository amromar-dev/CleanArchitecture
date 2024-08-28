namespace CleanArchitecture.Domain.BuildingBlocks.Interfaces
{
    public interface IDomainEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
