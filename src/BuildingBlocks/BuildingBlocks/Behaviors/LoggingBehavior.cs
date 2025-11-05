using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async  Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handling {RequestType} with content: {@Request}", typeof(TRequest).Name, request);

            var timer = new Stopwatch();
            timer.Start();
            var response = await next();

            timer.Stop();
            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
                logger.LogWarning("[PERFORMANCE] Long Running Request: {RequestType} took {TimeTaken} seconds to process.", 
                    typeof(TRequest).Name, timeTaken.TotalSeconds);

            logger.LogInformation("[END] Handled {RequestType} in {TimeTaken} seconds with response: {@Response}", 
                typeof(TRequest).Name, timeTaken.TotalSeconds, response);
            return response;
        }
    }
}
