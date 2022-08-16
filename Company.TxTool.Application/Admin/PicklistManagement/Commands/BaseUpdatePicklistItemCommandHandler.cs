using Company.TxTool.Application.Admin.PicklistManagement.Commands.UpdatePicklistItem;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands
{
    public abstract class BaseUpdatePicklistItemCommandHandler<T> : IRequestHandler<T> where T : UpdatePicklistItemCommand
    {
        protected readonly IApplicationDbContext _context;

        protected BaseUpdatePicklistItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(T dto, CancellationToken cancellationToken)
        {
            await UpdateExistingItem(dto, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        protected abstract Task UpdateExistingItem(T dto, CancellationToken cancellationToken);

        protected static void SetCommonProperties(UpdatePicklistItemCommand dto, BasePicklistItem existingItem)
        {
            existingItem.Name = dto.Name;
            existingItem.MemberOrderKey = dto.MemberOrderKey;
            existingItem.IsActive = dto.IsActive;
        }
    }
}