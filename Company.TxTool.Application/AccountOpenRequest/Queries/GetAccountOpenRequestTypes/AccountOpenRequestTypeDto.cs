using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequestTypes
{
    public class AccountOpenRequestTypeDto : IMapFrom<AccountOpenRequestType>
    {
        public AccountOpenRequestTypeDto()
        {
            Value = default!;
        }

        public string Value
        {
            get; set;
        }
    }
}