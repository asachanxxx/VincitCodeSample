using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Audit;
using Cushwake.TreasuryTool.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.EventHandlers
{
    public class UserUpsertedEventHandler : INotificationHandler<UserUpsertedEvent>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UserUpsertedEventHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task Handle(UserUpsertedEvent domainEvent, CancellationToken cancellationToken)
        {
            await CreateAudit(domainEvent, cancellationToken);
        }

        private async Task CreateAudit(UserUpsertedEvent domainEvent, CancellationToken cancellationToken)
        {
            var newUser = await _context.Users
                .Include(u => u.Role)
                .ThenInclude(r => r.ApplicationRoleBPermissions)
                .ThenInclude(rp => rp.Permission)
                .SingleAsync(u => u.Id == domainEvent.NewUser.Id, cancellationToken);

            _context.UserAudits.Add(new UserAudit(domainEvent.IsCreated, domainEvent.OldUser, newUser, _currentUserService.User));
        }
    }
}