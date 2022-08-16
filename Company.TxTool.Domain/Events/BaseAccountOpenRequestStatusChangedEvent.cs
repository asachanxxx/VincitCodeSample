using System;
using Ardalis.GuardClauses;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;

namespace Cushwake.TreasuryTool.Domain.Events
{
    public abstract class BaseAccountOpenRequestStatusChangedEvent : BaseEvent
    {
        public BaseAccountOpenRequestStatusChangedEvent(BaseAccountOpenRequest request)
        {
            Guard.Against.NullOrWhiteSpace(request.ClientName, nameof(request.ClientName), "Client name should be set at this state.");

            Id = request.Id;
            RequestorId = request.RequestedBy;
            ClientName = request.ClientName;
        }

        public int Id
        {
            get;
        }

        public int RequestorId
        {
            get;
        }

        public string ClientName
        {
            get;
        }
    }
}
