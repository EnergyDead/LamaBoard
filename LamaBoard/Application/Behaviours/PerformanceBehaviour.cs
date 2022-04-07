﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;

    public PerformanceBehaviour(
        ILogger<TRequest> logger
        )
    {
        _timer = new Stopwatch();

        _logger = logger;
    }

    public async Task<TResponse> Handle( TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next )
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if ( elapsedMilliseconds > 500 )
        {
            var requestName = typeof( TRequest ).Name;
            var userId = string.Empty;
            var userName = string.Empty;

            if ( !string.IsNullOrEmpty( userId ) )
            {
                userName = "testsUser";
            }

            _logger.LogWarning( "CleanArchitecture Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request );
        }

        return response;
    }
}
