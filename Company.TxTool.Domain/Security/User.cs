using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.Security;

public class User : BaseRowVersionedEntity, IBelongToTenant
{
    private string _name = default!;

    private User()
    {
        WorkEmail = default!;
        Role = default!;
    }

    public User(string name, string? firstName, string? lastName, string workEmail, Guid userGraphId, ApplicationRole role, bool isActive)
        : this()
    {
        Name = GetValidText(name, nameof(name), 255);
        FirstName = GetValidNullableText(firstName, nameof(FirstName), 255);
        LastName = GetValidNullableText(lastName, nameof(LastName), 255);
        WorkEmail = GetValidText(workEmail, nameof(WorkEmail), 255);

        if (userGraphId == Guid.Empty)
        {
            throw new ArgumentException("Guid is invalid.", nameof(userGraphId));
        }
        UserGraphId = userGraphId;

        Role = role;
        IsActive = isActive;
    }

    public Guid UserGraphId
    {
        get; private set;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = GetValidText(value, nameof(Name), 255);
        }
    }

    public string? FirstName
    {
        get; private set;
    }

    public string? LastName
    {
        get; private set;
    }

    public string WorkEmail
    {
        get; set;
    }

    public string NameAndEmail => $"{Name} ({WorkEmail})";

    public int ApplicationRoleID
    {
        get; set;
    }

    public bool IsActive
    {
        get; set;
    }

    public virtual ApplicationRole Role
    {
        get; set;
    }

    public string GetPermissionsCodesForAudit()
    {
        return string.Join(",", Role.ApplicationRoleBPermissions.Select(p => p.Permission?.PermissionCode ?? p.PermissionId.ToString()));
    }
}
