using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Picklist;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.UpdatePicklistItem
{
    [AuthorizeForPermission(PermissionEnum.AdminPicklistMgt)]
    public record UpdateAccountTypeCommand : UpdatePicklistItemCommand
    {
        public UpdateAccountTypeCommand()
        {
            ReconciliationFrequency = default!;
        }

        public string ReconciliationFrequency
        {
            get; set;
        }

        public ReconciliationFrequencyEnum ReconciliationFrequencyAsEnum => ReconciliationFrequencyEnum.FromName(ReconciliationFrequency);
    }

    public class UpdateAccountTypeCommandHandler : BaseUpdatePicklistItemCommandHandler<UpdateAccountTypeCommand>
    {
        public UpdateAccountTypeCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        protected override async Task UpdateExistingItem(UpdateAccountTypeCommand dto, CancellationToken cancellationToken)
        {
            var existingItem = await _context.PicklistItems
                .OfType<AccountType>()
                .SingleAsync(p => p.Id == dto.Id, cancellationToken);

            SetCommonProperties(dto, existingItem);
            existingItem.ReconciliationFrequency = dto.ReconciliationFrequencyAsEnum;
        }
    }
}
