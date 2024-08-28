namespace CleanArchitecture.Application.BuildingBlocks.Executions.Results
{
    /// <summary>
    /// Represents the result of a request, including the data and whether the request was successful.
    /// </summary>
    /// <typeparam name="T">The type of data returned by the request.</typeparam>
    /// <param name="Data">The data resulting from the request, if successful.</param>
    /// <param name="IsSuccess">A flag indicating whether the request was successful.</param>
    public record RequestResult<T>(T Data, bool IsSuccess) : IRequestResult<T>
    {
        /// <summary>
        /// Gets the timestamp of when the result was created.
        /// </summary>
        public DateTime Timestamp { get; private set; } = DateTime.Now;

        /// <summary>
        /// Creates a successful <see cref="RequestResult{T}"/> with the specified data.
        /// </summary>
        /// <param name="data">The data to include in the successful result.</param>
        /// <returns>A <see cref="RequestResult{T}"/> indicating success with the provided data.</returns>
        public static RequestResult<T> Success(T data)
        {
            return new RequestResult<T>(data, true);
        }

        /// <summary>
        /// Creates a failure <see cref="RequestResult{T}"/> with the specified data.
        /// </summary>
        /// <param name="failure">The data to include in the failure result.</param>
        /// <returns>A <see cref="RequestResult{T}"/> indicating failure with the provided data.</returns>
        public static RequestResult<T> Error(T failure)
        {
            return new RequestResult<T>(failure, false);
        }
    }
}
