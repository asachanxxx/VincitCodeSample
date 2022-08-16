using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Picklist;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistTypes
{
    public class PicklistTypeDto : IMapFrom<PicklistType>
    {
        public PicklistTypeDto()
        {
            Value = default!;
        }

        public string Value
        {
            get; set;
        }
    }
}