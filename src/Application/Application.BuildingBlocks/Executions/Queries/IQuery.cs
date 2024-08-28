﻿using MediatR;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results;

namespace CleanArchitecture.Application.BuildingBlocks.Executions.Queries
{
    /// <summary>
    /// Represents a query that can be sent to a handler to retrieve a result.
    /// </summary>
    /// <typeparam name="TResult">The type of result that the query will return.</typeparam>
    public interface IQuery<TResult> : IRequest<IRequestResult<TResult>>
    {
    }
}