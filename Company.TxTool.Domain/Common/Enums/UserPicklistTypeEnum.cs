using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Common.Enums
{
    public class UserPicklistTypeEnum : SmartEnum<UserPicklistTypeEnum>
    {
        private UserPicklistTypeEnum(string name, byte value) : base(name, value)
        {
        }

        public static readonly UserPicklistTypeEnum Reconciler = new(nameof(Reconciler), 1);
        public static readonly UserPicklistTypeEnum ReconciliationReviewer = new(nameof(ReconciliationReviewer), 2);
    }
}
