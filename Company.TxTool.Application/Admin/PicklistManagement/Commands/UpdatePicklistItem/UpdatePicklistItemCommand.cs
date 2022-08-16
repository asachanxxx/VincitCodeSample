using Company.TxTool.Application.Admin.PicklistManagement.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Commands.UpdatePicklistItem;

public record UpdatePicklistItemCommand : IRequest
{
    public UpdatePicklistItemCommand()
    {
        Name = default!;
        Type = default!;
    }

    public int Id
    {
        get; set;
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

public class UpdatePicklistItemCommandHandler : BaseUpdatePicklistItemCommandHandler<UpdatePicklistItemCommand>
{
    public UpdatePicklistItemCommandHandler(IApplicationDbContext context) : base(context)
    {
    }

    protected override async Task UpdateExistingItem(UpdatePicklistItemCommand dto, CancellationToken cancellationToken)
    {
        var existingItem = await _context.PicklistItems
            .SingleAsync(p => p.Id == dto.Id && p.Type == dto.Type, cancellationToken);

        SetCommonProperties(dto, existingItem);
    }
}