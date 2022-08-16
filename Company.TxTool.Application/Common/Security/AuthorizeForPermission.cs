using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Company.TxTool.Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeForPermission : Attribute
    {
        public PermissionEnum Permission
        {
            get;
        }

        public AuthorizeForPermission(PermissionEnum permission)
        {
            Permission = permission;
        }
    }
}
