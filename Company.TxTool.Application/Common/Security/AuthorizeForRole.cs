using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Company.TxTool.Application.Common.Security;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeForAdministrator : AuthorizeForRole
{
    public override ApplicationRoleEnum Role => ApplicationRoleEnum.Administrator;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeForBankAdmin : AuthorizeForRole
{
    public override ApplicationRoleEnum Role => ApplicationRoleEnum.BankAdmin;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeForGeneralAccounting : AuthorizeForRole
{
    public override ApplicationRoleEnum Role => ApplicationRoleEnum.GeneralAccounting;
}

public abstract class AuthorizeForRole : Attribute
{
    public abstract ApplicationRoleEnum Role
    {
        get;
    }

    public string Permission { get; set; } = string.Empty;
}