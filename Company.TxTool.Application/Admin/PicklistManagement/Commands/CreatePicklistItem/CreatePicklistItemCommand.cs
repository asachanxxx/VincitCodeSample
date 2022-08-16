using Company.TxTool.Application.Admin.PicklistManagement.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.CreatePicklistItem;

[AuthorizeForPermission(PermissionEnum.AdminPicklistMgt)]
public record CreatePicklistItemCommand : IRequest
{
    public CreatePicklistItemCommand()
    {
        Name = default!;
        Type = default!;
    }

    public PicklistTypeEnum Type
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public int? MemberOrderKey
    {
        get; set;
    }

    public bool IsActive
    {
        get; set;
    }
}

public class CreatePicklistItemCommandHandler : BaseCreatePicklistItemCommandHandler<CreatePicklistItemCommand>
{
    public CreatePicklistItemCommandHandler(IApplicationDbContext context) : base(context)
    {
    }

    protected override BasePicklistItem GetNewItem(CreatePicklistItemCommand dto)
    {
        return dto.Type.GetPicklistItem(dto.Name, dto.IsActive);
    }
}