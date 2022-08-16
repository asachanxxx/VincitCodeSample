using System;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Picklist;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems
{
    public class CurrencyDto : PicklistItemDto, IMapFrom<Currency>
    {
        public CurrencyDto()
        {
            Sign = default!;
        }

        public string Sign
        {
            get; set;
        }
    }
}
