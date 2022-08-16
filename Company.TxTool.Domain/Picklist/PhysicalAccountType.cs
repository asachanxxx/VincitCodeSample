using System;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class PhysicalAccountType : BasePicklistItem
    {
        public PhysicalAccountType(string name, bool isActive) : base(PicklistTypeEnum.PhysicalAccountType, name, isActive)
        {
        }
    }
}
