using MediatR;

namespace CQRSMediatRExample.MediatR.Behaviors
{
    public class LogginBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LogginBehavior<TRequest, TResponse>> _logger;

        public LogginBehavior(ILogger<LogginBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
