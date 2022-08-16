using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.Events
{
    public class AccountOpenRequestSubmittedEvent : BaseAccountOpenRequestStatusChangedEvent
    {
        public AccountOpenRequestSubmittedEvent(BaseAccountOpenRequest request) : base(request)
        {
        }
    }
}
