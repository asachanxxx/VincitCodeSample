using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly string _currentUserWorkEmail;
    private readonly IDbContextLite _context;

    private Lazy<UserLite> _lazyUser => new(() => _context.GetActiveUser(_currentUserWorkEmail).Result);

    public CurrentUserService(ICurrentIdentityService currentIdentityService, IDbContextLite context)
    {
        _currentUserWorkEmail = currentIdentityService.Identity;
        _context = context;
    }

    public UserLite User => _lazyUser.Value;
}