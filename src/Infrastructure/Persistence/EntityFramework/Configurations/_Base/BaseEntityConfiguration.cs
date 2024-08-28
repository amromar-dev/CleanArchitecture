using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;
using CleanArchitecture.Domain.BuildingBlocks.ValueTypes;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity, Key> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity<Key>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.Auditing, cb =>
            {
                cb.Property(nameof(Auditing.CreatedAt)).HasColumnName(nameof(Auditing.CreatedAt));
                cb.Property(nameof(Auditing.CreatedBy)).HasColumnName(nameof(Auditing.CreatedBy));
                cb.Property(nameof(Auditing.ModifiedAt)).HasColumnName(nameof(Auditing.ModifiedAt));
                cb.Property(nameof(Auditing.ModifiedBy)).HasColumnName(nameof(Auditing.ModifiedBy));
                cb.Property(nameof(Auditing.DeletedAt)).HasColumnName(nameof(Auditing.DeletedAt));
                cb.Property(nameof(Auditing.DeletedBy)).HasColumnName(nameof(Auditing.DeletedBy));
                cb.Property(nameof(Auditing.IsDeleted)).HasColumnName(nameof(Auditing.IsDeleted));
            });
        }
    }
}