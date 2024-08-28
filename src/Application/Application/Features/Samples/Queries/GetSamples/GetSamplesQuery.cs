using CleanArchitecture.Application.BuildingBlocks.Executions.Queries;
using CleanArchitecture.Application.Features.Samples.Outputs;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;

namespace CleanArchitecture.Application.Features.Samples.Queries
{
    public class GetSamplesQuery : IQuery<PageList<SampleOutput>>
    {
        public GetSamplesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
