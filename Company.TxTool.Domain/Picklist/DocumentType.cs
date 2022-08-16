using System;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class DocumentType : BasePicklistItem
    {
        public DocumentType(string name, bool isActive) : base(PicklistTypeEnum.DocumentType, name, isActive)
        {
        }
    }
}
