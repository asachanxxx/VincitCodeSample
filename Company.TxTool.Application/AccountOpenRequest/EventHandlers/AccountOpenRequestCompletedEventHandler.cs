using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Events;
using Cushwake.TreasuryTool.Domain.Notification;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.EventHandlers
{
    public class AccountOpenRequestCompletedEventHandler : INotificationHandler<AccountOpenRequestCompletedEvent>
    {
        private readonly IApplicationDbContext _context;

        public AccountOpenRequestCompletedEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AccountOpenRequestCompletedEvent domainEvent, CancellationToken cancellationToken)
        {
            await CreateNotification(domainEvent, cancellationToken);
        }

        private async Task CreateNotification(AccountOpenRequestCompletedEvent domainEvent, CancellationToken cancellationToken)
        {
            //await CreateAccountRegister(domainEvent);
            CreateNotificationForRequestor(domainEvent);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateAccountRegister(AccountOpenRequestCompletedEvent domainEvent)
        {
            var request = await _context.AccountOpenRequests.FindAsync(domainEvent.Id);
            var accountRegister = request!.Type.GetAccountRegisterBuilder(request).Build();
            _context.AccountRegisters.Add(accountRegister);
        }

        private void CreateNotificationForRequestor(AccountOpenRequestCompletedEvent domainEvent)
        {
            _context.Notifications.Add(
                            new Notification(
                                domainEvent.RequestorId,
                                NotificationTypeEnum.AccountOpenRequestCompletion,
                                $"Your account open request for '{domainEvent.ClientName}' was approved.",
                                domainEvent.Id));
        }
    }
}
