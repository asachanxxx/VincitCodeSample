using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.UpdateAccountOpenRequest;

[AuthorizeForPermission(PermissionEnum.AorSave)]
public record UpdatePhysicalAccountOpenRequestByRequstorCommand : IRequest<RowVersionResult>
{
    public UpdatePhysicalAccountOpenRequestByRequstorCommand(Guid guid, PhysicalAccountOpenRequestRequestorSectionDto payload)
    {
        Guid = guid;
        Payload = payload;
    }

    public PhysicalAccountOpenRequestRequestorSectionDto Payload
    {
        get;
    }

    public Guid Guid
    {
        get;
    }
}

public class UpdatePhysicalAccountOpenRequestByRequstorCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<UpdatePhysicalAccountOpenRequestByRequstorCommand, RowVersionResult>
{
    public UpdatePhysicalAccountOpenRequestByRequstorCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<RowVersionResult> Handle(UpdatePhysicalAccountOpenRequestByRequstorCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(command.Guid);
        var entity = await GetUpdatedPhysicalEntityForRequestor(command.Guid, command.Payload, cancellationToken);

        _mapper.Map(command.Payload, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new RowVersionResult(entity);
    }
}
