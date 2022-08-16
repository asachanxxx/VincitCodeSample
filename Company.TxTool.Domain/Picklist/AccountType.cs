using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class AccountType : BasePicklistItem
    {
        public AccountType(string name, bool isActive) : base(PicklistTypeEnum.AccountType, name, isActive)
        {
        }

        public ReconciliationFrequencyEnum? ReconciliationFrequency
        {
            get; set;
        }
    }
}
