using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Picklist;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems
{
    public class PicklistItemDto : IMapFrom<BasePicklistItem>
    {
        public PicklistItemDto()
        {
            Code = default!;
            Name = default!;
        }

        public int Id
        {
            get; set;
        }

        public string Code
        {
            get; set;
        }

        public string Name
        {
            get; set;
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
