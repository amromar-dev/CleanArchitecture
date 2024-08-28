using AutoMapper;
using CleanArchitecture.Application.Features.Samples.Outputs;
using CleanArchitecture.Domain.Samples;

namespace CleanArchitecture.Application.Features.Samples.Mappings
{
    public class Configurations : Profile
    {
        public Configurations()
        {
            CreateMap<Sample, SampleOutput>();
        }
    }
}
