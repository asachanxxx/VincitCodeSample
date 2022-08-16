using Company.TxTool.Application.Common.Interfaces;

namespace Cushwake.TreasuryTool.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    private readonly ICurrentUserService _currentUserService;

    public DateTimeService(ICurrentUserService currentUsertService)
    {
        _currentUserService = currentUsertService;
    }

    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime TenantLocalToday => TenantLocalNow.Date;

    public DateTime TenantLocalNow
    {
        get
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(_currentUserService.User.TenantTimeZoneName);
            return TimeZoneInfo.ConvertTime(UtcNow, tz);
        }
    }
}
