using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Events;
using Cushwake.TreasuryTool.Domain.Notification;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.EventHandlers
{
    public class AccountOpenRequestRejectedEventHandler : INotificationHandler<AccountOpenRequestRejectedEvent>
    {
        private readonly IApplicationDbContext _context;

        public AccountOpenRequestRejectedEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AccountOpenRequestRejectedEvent domainEvent, CancellationToken cancellationToken)
        {
            await CreateNotification(domainEvent, cancellationToken);
        }

        private async Task CreateNotification(AccountOpenRequestRejectedEvent domainEvent, CancellationToken cancellationToken)
        {
            _context.Notifications.Add(
                new Notification(
                    domainEvent.RequestorId,
                    NotificationTypeEnum.AccountOpenRequestRejection,
                    $"Your account open request for '{domainEvent.ClientName}' was rejected.",
                    domainEvent.Id));
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}