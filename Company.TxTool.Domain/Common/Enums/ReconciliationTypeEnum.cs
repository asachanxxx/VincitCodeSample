using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Common.Enums
{
    public class ReconciliationTypeEnum : SmartEnum<ReconciliationTypeEnum>
    {
        protected ReconciliationTypeEnum(string name, int value) : base(name, value)
        {
        }

        public static readonly ReconciliationTypeEnum Unknown = new(nameof(Unknown), 0);
        public static readonly ReconciliationTypeEnum Simple = new(nameof(Simple), 1);
        public static readonly ReconciliationTypeEnum Complex = new(nameof(Complex), 2);
    }
}
