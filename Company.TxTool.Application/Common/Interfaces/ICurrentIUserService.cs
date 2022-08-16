using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Common.Interfaces;

public interface ICurrentUserService
{
    UserLite User
    {
        get;
    }
}