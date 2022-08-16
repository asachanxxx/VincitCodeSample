using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.FunctionApi.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Company.TxTool.FunctionApi.Services;

public class CloudIdentityService : ICurrentIdentityService
{
    private readonly string _identity;

    public CloudIdentityService(IHttpContextAccessor httpContextAccessor)
    {
        var identity = httpContextAccessor.HttpContext?.User?.Identity?.Name;
        if (string.IsNullOrWhiteSpace(identity))
        {
            throw new AnonymousRequestException();
        }

        _identity = identity;
    }

    public string Identity => _identity;
}

public class MockIdentityService : ICurrentIdentityService
{
    private readonly string _identity;

    public MockIdentityService(IEnvironmentSettings settings)
    {
        _identity = settings.MockDevUserEmail;
    }

    public string Identity => _identity;
}
