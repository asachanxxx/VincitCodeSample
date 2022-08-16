using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class Bank : BasePicklistItem
    {
        public Bank(string name, bool isActive) : base(PicklistTypeEnum.Bank, name, isActive)
        {
        }
    }
}