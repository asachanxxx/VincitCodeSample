using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Cushwake.TreasuryTool.Domain.Security;

public class ApplicationRole : BaseAuditableEntity
{
    private int? _copiedFromApplicationRoleID;

    private ApplicationRole()
    {
        ApplicationRoleCode = default!;

        ApplicationRoleBPermissions = new HashSet<ApplicationRoleBPermission>();
    }

    public ApplicationRole(string code, int copiedFromId) : this()
    {
        ApplicationRoleCode = ApplicationRoleEnum.FromName(code, true);
        ApplicationRoleName = null;
        CopiedFromApplicationRoleID = copiedFromId;
        IsStandardRole = false;
        IsActive = true;
    }

    public ApplicationRoleEnum ApplicationRoleCode
    {
        get; private set;
    }

    public string? ApplicationRoleName
    {
        get; set;
    }

    public bool IsStandardRole
    {
        get; private set;
    }

    public int? CopiedFromApplicationRoleID
    {
        get
        {
            return _copiedFromApplicationRoleID;
        }
        set
        {
            _copiedFromApplicationRoleID = GetValidId(value, nameof(CopiedFromApplicationRoleID));
        }
    }

    public bool IsActive
    {
        get; private set;
    }

    public int? MemberOrderKey
    {
        get; private set;
    }

    public virtual ApplicationRole? CopiedFromApplicationRole
    {
        get; private set;
    }

    public virtual ICollection<ApplicationRoleBPermission> ApplicationRoleBPermissions
    {
        get; private set;
    }

    public void AddPermission(int permissionId)
    {
        if (ApplicationRoleBPermissions.Any(rp => rp.PermissionId == permissionId))
        {
            return;
        }

        ApplicationRoleBPermissions.Add(new ApplicationRoleBPermission(permissionId));
    }
}
