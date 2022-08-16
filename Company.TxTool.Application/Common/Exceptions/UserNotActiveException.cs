using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Common.Exceptions;

public class UserNotActiveException : TreasuryToolApplicationException
{
    public UserLite User
    {
        get; private set;
    }

    public UserNotActiveException(UserLite user) : base(ExceptionCode.UserNotActive, $"The user '{user.Name} ({user.WorkEmail})' is deactivated.")
    {
        User = user;
    }
}