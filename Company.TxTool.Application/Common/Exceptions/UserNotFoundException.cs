namespace Company.TxTool.Application.Common.Exceptions;

public class UserNotFoundException : TreasuryToolApplicationException
{
    public string Email
    {
        get; private set;
    }

    public UserNotFoundException(string email) : base(ExceptionCode.UserNotFound, $"There is no user registered under '{email}'.")
    {
        Email = email;
    }
}