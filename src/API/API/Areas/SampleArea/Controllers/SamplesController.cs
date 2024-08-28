using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.API.DependencyInjections.Extensions;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results;
using CleanArchitecture.Application.Features.Samples.Outputs;
using CleanArchitecture.Application.Features.Samples.Commands;
using CleanArchitecture.Application.Features.Samples.Queries;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;
using CleanArchitecture.API.BuildingBlocks.Controllers;

namespace CleanArchitecture.API.Areas.SampleArea.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Area(AreaExtension.SampleArea)]
    public class SamplesController : BaseController
    {
        /// <summary>
        /// Creates a new sample entity.
        /// </summary>
        [HttpPost]
        public Task<IRequestResult<int>> Create(CreateSampleCommand command) 
            => ExecuteCommandAsync(command);

        /// <summary>
        /// Retrieves a paginated list of sample entities.
        /// </summary>
        [HttpGet]
        public Task<IRequestResult<PageList<SampleOutput>>> Get(int pageNumber, int pageSize) 
            => ExecuteQueryAsync(new GetSamplesQuery(pageNumber, pageSize));
    }
}
