using Company.TxTool.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Company.TxTool.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentIdentityService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentIdentityService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.Identity ?? string.Empty;
        var userName = string.Empty;

        //if (!string.IsNullOrEmpty(userId))
        //{
        //    userName = await _identityService.GetUserNameAsync(userId);
        //}

        _logger.LogInformation("Src Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);

        return Task.CompletedTask;
    }
}