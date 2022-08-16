using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.UpdateAccountOpenRequest;

[AuthorizeForPermission(PermissionEnum.AorSave)]
public record UpdateVirtualAccountOpenRequestByRequestorCommand : IRequest<RowVersionResult>
{
    public UpdateVirtualAccountOpenRequestByRequestorCommand(Guid guid, VirtualAccountOpenRequestRequestorSectionDto payload)
    {
        Guid = guid;
        Payload = payload;
    }

    public VirtualAccountOpenRequestRequestorSectionDto Payload
    {
        get;
    }

    public Guid Guid
    {
        get;
    }
}

public class UpdateVirtualAccountOpenRequestByRequestorCommandHandler : BaseVirtualAccountOpenRequestCommandHandler, IRequestHandler<UpdateVirtualAccountOpenRequestByRequestorCommand, RowVersionResult>
{
    public UpdateVirtualAccountOpenRequestByRequestorCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<RowVersionResult> Handle(UpdateVirtualAccountOpenRequestByRequestorCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(command.Guid);
        var entity = await GetUpdatedEntityForReviewer(command.Guid, command.Payload, cancellationToken);

        _mapper.Map(command.Payload, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new RowVersionResult(entity);
    }
}
