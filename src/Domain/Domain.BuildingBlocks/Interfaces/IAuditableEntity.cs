using CleanArchitecture.Domain.BuildingBlocks.ValueTypes;

namespace CleanArchitecture.Domain.BuildingBlocks.Interfaces
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets the auditing information for this entity.
        /// </summary>
        public Auditing Auditing { get; }
    }
}
