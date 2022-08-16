using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Common.Queries
{
    public class UserPicklistItemDto : IMapFrom<User>
    {
        public UserPicklistItemDto()
        {
            Name = default!;
            WorkEmail = default!;
        }

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string WorkEmail
        {
            get; set;
        }
    }
}
