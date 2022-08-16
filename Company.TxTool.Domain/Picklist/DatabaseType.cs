using System;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class DatabaseType : BasePicklistItem
    {
        public DatabaseType(string name, bool isActive) : base(PicklistTypeEnum.DatabaseType, name, isActive)
        {
        }
    }
}
