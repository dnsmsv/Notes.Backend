using MediatR;
using Notes.Application.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        private readonly ICurrentUserService currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService) =>
            this.currentUserService = currentUserService;

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            var userId = currentUserService.UserId;

            Log.Information("Notes Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);

            var response = await next();
            return response;
        }
    }
}
