using System;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class Currency : BasePicklistItem
    {
        public Currency(string name, bool isActive) : base(PicklistTypeEnum.Currency, name, isActive)
        {
        }

        public string? Sign
        {
            get; set;
        }
    }
}
