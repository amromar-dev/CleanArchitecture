using CleanArchitecture.Domain.BuildingBlocks.Interfaces;

namespace CleanArchitecture.Domain.Samples.Events
{
    public record SampleNameChangedEvent(int Id) : IDomainEvent;
}
