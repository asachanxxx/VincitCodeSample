namespace Company.TxTool.Application.Common.Interfaces;

public interface IDateTime
{
    DateTime UtcNow
    {
        get;
    }

    DateTime TenantLocalToday
    {
        get;
    }

    DateTime TenantLocalNow
    {
        get;
    }
}
