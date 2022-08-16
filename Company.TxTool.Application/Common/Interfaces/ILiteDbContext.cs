using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Common.Interfaces;

public interface IDbContextLite
{
    Task<UserLite> GetActiveUser(string workEmail);
}