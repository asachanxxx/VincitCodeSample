using System;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Common
{
    public partial class ErrorMessage
    {
        public int ErrorMessageId
        {
            get; set;
        }

        public string? ErrorMessageCode
        {
            get; set;
        }

        public string ErrorMessageName { get; set; } = null!;
        public string ErrorMessageText { get; set; } = null!;

        public bool IsActive
        {
            get; set;
        }

        public int? MemberOrderKey
        {
            get; set;
        }

        public DateTime? Modified
        {
            get; set;
        }

        public int? ModifiedbyId
        {
            get; set;
        }

        public virtual User? Modifiedby
        {
            get; set;
        }
    }
}