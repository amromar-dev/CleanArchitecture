using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.Samples;
using CleanArchitecture.Infrastructure.Persistence.EntityFramework.Configurations.Base;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.Configurations
{
    public class SampleConfiguration : BaseEntityConfiguration<Sample, int>
    {
        public override void Configure(EntityTypeBuilder<Sample> builder)
        {
            base.Configure(builder);

            builder.ToTable("Samples");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(Constants.RegularStringLength);
        }
    }
}
