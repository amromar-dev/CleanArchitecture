using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.BuildingBlocks.Executions.Commands;
using CleanArchitecture.Application.BuildingBlocks.Executions.Queries;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results;
using CleanArchitecture.Application.BuildingBlocks.Executions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results.Errors;

namespace CleanArchitecture.API.BuildingBlocks.Controllers
{
    [ApiController]
    [Route("[area]/[controller]")]
    [ProducesResponseType(typeof(RequestResult<RequestError>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(RequestResult<>), StatusCodes.Status200OK)]
    public class BaseController : ControllerBase
    {
        private IRequestExecution _requestExecution;
        protected IRequestExecution RequestExecution => _requestExecution  
            ??= HttpContext.RequestServices.GetService<IRequestExecution>()
            ?? throw new ArgumentNullException(nameof(RequestExecution), "IRequestExecution service not registered");

        /// <summary>
        /// Execute command with return result
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<IRequestResult<TResult>> ExecuteCommandAsync<TResult>(ICommand<TResult> command) 
            => RequestExecution.ExecuteAsync(command);

        /// <summary>
        /// Execute query
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<IRequestResult<TResult>> ExecuteQueryAsync<TResult>(IQuery<TResult> command) 
            => RequestExecution.QueryAsync(command);

        /// <summary>
        /// Execute command without returned result
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<IRequestResult<bool>> ExecuteAsync<TResult>(ICommand command)
        {
            await RequestExecution.ExecuteAsync(command);
            return RequestResult<bool>.Success(true);
        }
    }
}
