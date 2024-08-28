using AutoMapper;
using CleanArchitecture.Application.BuildingBlocks.Executions.Queries;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results;
using CleanArchitecture.Application.Features.Samples.Outputs;
using CleanArchitecture.Domain.Samples;
using CleanArchitecture.Domain.Samples.Interfaces;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;

namespace CleanArchitecture.Application.Features.Samples.Queries
{
    public class GetSamplesQueryHandler(ISampleRepository sampleRepository, IMapper mapper) : QueryHandler<GetSamplesQuery, PageList<SampleOutput>>
    {
        public override async Task<IRequestResult<PageList<SampleOutput>>> Handle(GetSamplesQuery request, CancellationToken cancellationToken)
        {
            PageList<Sample> samples = await sampleRepository.PageListActiveAsync(request.PageNumber, request.PageSize);
            PageList<SampleOutput> results = mapper.Map<PageList<SampleOutput>>(samples);

            return Result(results);
        }
    }
}
