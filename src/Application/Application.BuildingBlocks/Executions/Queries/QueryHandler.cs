using CleanArchitecture.Application.BuildingBlocks.Executions.Results;

namespace CleanArchitecture.Application.BuildingBlocks.Executions.Queries
{
    /// <summary>
    /// Defines a handler for processing queries and returning results.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query that this handler can process. Must implement <see cref="IQuery{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of result that the query handler returns.</typeparam>
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public abstract Task<IRequestResult<TResult>> Handle(TQuery request, CancellationToken cancellationToken);

        public IRequestResult<TResult> Result(TResult result)
        {
            return RequestResult<TResult>.Success(result);
        }
    }
}