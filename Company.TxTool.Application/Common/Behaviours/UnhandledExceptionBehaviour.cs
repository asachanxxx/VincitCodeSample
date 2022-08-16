using Cushwake.TreasuryTool.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (AggregateException ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex.InnerException ?? ex, "Src Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw ex.InnerException ?? ex;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new EntityModifiedElsewhereException();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "Src Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}