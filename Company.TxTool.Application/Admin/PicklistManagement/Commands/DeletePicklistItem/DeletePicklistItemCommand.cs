using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.DeletePicklistItem
{
    [AuthorizeForPermission(PermissionEnum.AdminPicklistMgt)]
    public record DeletePicklistItemCommand : IRequest
    {
        public DeletePicklistItemCommand(PicklistTypeEnum picklistType, int id)
        {
            Type = picklistType;
            Id = id;
        }

        public int Id
        {
            get; private set;
        }

        public PicklistTypeEnum Type
        {
            get; private set;
        }
    }

    public class DeletePicklistItemCommandHandler : IRequestHandler<DeletePicklistItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePicklistItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePicklistItemCommand request, CancellationToken cancellationToken)
        {
            var toBeDeletedEntity = await _context.PicklistItems.SingleOrDefaultAsync(p => p.Type == request.Type && p.Id == request.Id, cancellationToken);
            if (toBeDeletedEntity == null)
            {
                throw new NotFoundException(request.Type.ToString(), request.Id);
            }

            _context.PicklistItems.Remove(toBeDeletedEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}