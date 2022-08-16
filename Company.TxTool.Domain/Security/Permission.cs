using Cushwake.TreasuryTool.Domain.Common.BaseEntities;

namespace Cushwake.TreasuryTool.Domain.Security
{
    public class Permission : BaseAuditableEntity
    {
        private Permission()
        {
            PermissionCode = default!;
        }

        public string PermissionCode
        {
            get; set;
        }

        public string? PermissionName
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

        public int? MemberOrderKey
        {
            get; set;
        }
    }
}
