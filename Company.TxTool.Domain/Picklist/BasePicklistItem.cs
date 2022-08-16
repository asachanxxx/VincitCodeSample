using System;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public abstract class BasePicklistItem : BaseAuditableEntity, IBelongToTenant
    {
        private string _name = default!;

        protected BasePicklistItem(PicklistTypeEnum type, string name, bool isActive)
        {
            Type = type;
            Name = GetValidText(name, nameof(name), 255);
            Code = Name;
            IsActive = isActive;
        }

        public string Code
        {
            get;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = GetValidText(value, nameof(Name), 255);
            }
        }

        public PicklistTypeEnum Type
        {
            get; private set;
        }

        public int? MemberOrderKey
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }
    }
}
