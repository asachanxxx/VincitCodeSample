using System;
using Cushwake.TreasuryTool.Domain.Events;
using Stateless;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class DefaultAccountOpenRequestWorkflow : IAccountOpenRequestWorkflow
    {
        private StateMachine<AccountOpenRequestStatusEnum, AccountOpenRequestTrigger> _machine;

        public DefaultAccountOpenRequestWorkflow(BaseAccountOpenRequest request)
        {
            _machine = new StateMachine<AccountOpenRequestStatusEnum, AccountOpenRequestTrigger>(() => request.Status, (newState) => request.Status = newState);

            _machine.Configure(AccountOpenRequestStatusEnum.Draft)
                .Permit(AccountOpenRequestTrigger.Submitting, AccountOpenRequestStatusEnum.Submitted);

            _machine.Configure(AccountOpenRequestStatusEnum.Submitted)
                .Permit(AccountOpenRequestTrigger.StartReviewing, AccountOpenRequestStatusEnum.InReview);

            _machine.Configure(AccountOpenRequestStatusEnum.InReview)
                .Permit(AccountOpenRequestTrigger.Rejecting, AccountOpenRequestStatusEnum.Rejected)
                .Permit(AccountOpenRequestTrigger.Completing, AccountOpenRequestStatusEnum.Completed);

            _machine.Configure(AccountOpenRequestStatusEnum.Rejected)
                .OnEntry(t => request.AddDomainEvent(new AccountOpenRequestRejectedEvent(request)))
                .Permit(AccountOpenRequestTrigger.Submitting, AccountOpenRequestStatusEnum.Submitted);

            _machine.Configure(AccountOpenRequestStatusEnum.Completed)
                .OnEntry(t => request.AddDomainEvent(new AccountOpenRequestCompletedEvent(request)));
        }

        public void Fire(AccountOpenRequestTrigger trigger)
        {
            _machine.Fire(trigger);
        }
    }
}
