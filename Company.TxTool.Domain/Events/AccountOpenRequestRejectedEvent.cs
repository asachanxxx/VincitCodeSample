using System;
using Ardalis.GuardClauses;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.Events
{
    public class AccountOpenRequestRejectedEvent : BaseAccountOpenRequestStatusChangedEvent
    {
        public AccountOpenRequestRejectedEvent(BaseAccountOpenRequest request) : base(request)
        {
            Guard.Against.Null(request.ReviewedBy, nameof(request.ReviewedBy), "ReviewedBy should be set at this state.");

            ReviewerId = request.ReviewedBy.Value;
        }

        public int ReviewerId
        {
            get;
        }
    }
}
