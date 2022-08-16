using Company.TxTool.Application.Admin.PicklistManagement.Commands.CreatePicklistItem;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Picklist;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.CreateAccountType;

[AuthorizeForPermission(PermissionEnum.AdminPicklistMgt)]
public record CreateAccountTypeCommand : CreatePicklistItemCommand
{
    public CreateAccountTypeCommand()
    {
        ReconciliationFrequency = default!;
    }

    public string ReconciliationFrequency
    {
        get; set;
    }

    public ReconciliationFrequencyEnum ReconciliationFrequencyAsEnum => ReconciliationFrequencyEnum.FromName(ReconciliationFrequency);
}

public class CreateAccountTypeCommandHandler : BaseCreatePicklistItemCommandHandler<CreateAccountTypeCommand>
{
    public CreateAccountTypeCommandHandler(IApplicationDbContext context) : base(context)
    {
    }

    protected override BasePicklistItem GetNewItem(CreateAccountTypeCommand dto)
    {
        return new AccountType(dto.Name, dto.IsActive) { ReconciliationFrequency = dto.ReconciliationFrequencyAsEnum };
    }
}
