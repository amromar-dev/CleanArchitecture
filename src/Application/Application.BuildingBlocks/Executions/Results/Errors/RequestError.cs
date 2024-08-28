namespace CleanArchitecture.Application.BuildingBlocks.Executions.Results.Errors
{
    /// <summary>
    /// Represents a error result from a request, including a description and a code.
    /// </summary>
    /// <param name="ErrorMessage">A description of the error.</param>
    /// <param name="ErrorCode">A code representing the type of error.</param>
    public record RequestError(string ErrorMessage, int ErrorCode);
}
