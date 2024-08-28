using CleanArchitecture.Application.BuildingBlocks.Executions.Results;

namespace CleanArchitecture.Application.BuildingBlocks.Executions.Commands
{
    /// <summary>
    /// Defines a handler for processing queries and returning results.
    /// </summary>
    /// <typeparam name="TCommand">The type of the Command that this handler can process. Must implement <see cref="ICommand{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of result that the Command handler returns.</typeparam>
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        public abstract Task<IRequestResult<TResult>> Handle(TCommand request, CancellationToken cancellationToken);

        public IRequestResult<TResult> Result(TResult result)
        {
            return RequestResult<TResult>.Success(result);
        }
    }
}