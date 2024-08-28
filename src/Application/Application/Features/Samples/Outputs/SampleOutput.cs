using CleanArchitecture.Domain.Samples.Enums;

namespace CleanArchitecture.Application.Features.Samples.Outputs
{
    public class SampleOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SampleStatus Status { get; set; }
    }
}
