using System;

namespace Cushwake.TreasuryTool.Domain.Security
{
    public class ApplicationRoleBPermission
    {
        private ApplicationRoleBPermission()
        {
            ApplicationRole = default!;
            Permission = default!;
        }

        public ApplicationRoleBPermission(int permissionId) : this()
        {
            PermissionId = permissionId;
            IsDefault = false;
            IsActive = true;
        }

        public int ApplicationRoleId
        {
            get; set;
        }

        public int PermissionId
        {
            get; set;
        }

        public bool IsDefault
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

        public DateTime? Created
        {
            get; set;
        }

        public int? CreatedById
        {
            get; set;
        }

        public DateTime? Modified
        {
            get; set;
        }

        public int? ModifiedById
        {
            get; set;
        }

        public virtual ApplicationRole ApplicationRole
        {
            get; set;
        }

        public Permission Permission
        {
            get; set;
        }
    }
}
