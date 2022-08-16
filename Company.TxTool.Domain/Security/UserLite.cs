using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Cushwake.TreasuryTool.Domain.Security
{
    public class UserLite
    {
        private HashSet<PermissionEnum> _permissions;

        public UserLite()
        {
            Name = default!;
            WorkEmail = default!;
            Role = default!;
            TenantCode = default!;
            TenantCultureCode = default!;
            TenantTimeZoneName = default!;
            _permissions = new HashSet<PermissionEnum>();
        }

        public int UserID
        {
            get; set;
        }

        public Guid UserGraphID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string WorkEmail
        {
            get; set;
        }

        public int ApplicationRoleID
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

        public int TenantId
        {
            get; set;
        }

        public string TenantCode
        {
            get; set;
        }

        public string TenantCultureCode
        {
            get; set;
        }

        public string TenantTimeZoneName
        {
            get; set;
        }

        public ApplicationRoleEnum Role
        {
            get; set;
        }

        public IEnumerable<PermissionEnum> Permissions => _permissions;

        public bool IsInRole(ApplicationRoleEnum role)
        {
            return Role == role;
        }

        public bool HasPermission(PermissionEnum permission)
        {
            return Permissions.Contains(permission);
        }

        public void LoadPermissions(IEnumerable<string> permissions)
        {
            _permissions.UnionWith(permissions.Select(p => Enum.Parse<PermissionEnum>(p)));
        }
    }
}
