using Company.TxTool.Application.Admin.PicklistManagement.Commands.CreatePicklistItem;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands
{
    public abstract class BaseCreatePicklistItemCommandHandler<T> : IRequestHandler<T, Unit> where T : CreatePicklistItemCommand
    {
        protected readonly IApplicationDbContext _context;

        protected BaseCreatePicklistItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(T dto, CancellationToken cancellationToken)
        {
            await EnsurePicklistItemDoesNotExist(dto, cancellationToken);

            var newItem = GetNewItem(dto);

            _context.PicklistItems.Add(newItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        protected abstract BasePicklistItem GetNewItem(T dto);

        private async Task EnsurePicklistItemDoesNotExist(T dto, CancellationToken cancellationToken)
        {
            var existingItem = await _context.PicklistItems.AsNoTracking()
                .Where(p => p.Type == dto.Type && p.Name == dto.Name)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingItem is not null)
            {
                throw new EntityAlreadyExistsException<BasePicklistItem>(existingItem);
            }
        }
    }
}