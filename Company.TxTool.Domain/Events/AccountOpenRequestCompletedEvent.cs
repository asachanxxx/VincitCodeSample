using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.Events
{
    public class AccountOpenRequestCompletedEvent : BaseAccountOpenRequestStatusChangedEvent
    {
        public AccountOpenRequestCompletedEvent(BaseAccountOpenRequest request) : base(request)
        {
        }
    }
}
