using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Common.Enums
{
    public class TenantEnum : SmartEnum<TenantEnum>
    {
        protected TenantEnum(string name, int value) : base(name, value)
        {
        }

        public static readonly TenantEnum DEFAULT = new(nameof(DEFAULT), 0);
        public static readonly TenantEnum AS = new(nameof(AS), 1);
        public static readonly TenantEnum GOS = new(nameof(GOS), 2);
        public static readonly TenantEnum US = new(nameof(US), 2);
    }
}
