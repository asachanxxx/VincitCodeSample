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
public record UpdatePhysicalAccountOpenRequestByReviewerCommand : IRequest<RowVersionResult>
{
    public UpdatePhysicalAccountOpenRequestByReviewerCommand(Guid guid, PhysicalAccountOpenRequestReviewerSectionDto payload)
    {
        Guid = guid;
        Payload = payload;
    }

    public PhysicalAccountOpenRequestReviewerSectionDto Payload
    {
        get;
    }

    public Guid Guid
    {
        get;
    }
}

public class UpdatePhysicalAccountOpenRequestByReviewerCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<UpdatePhysicalAccountOpenRequestByReviewerCommand, RowVersionResult>
{
    public UpdatePhysicalAccountOpenRequestByReviewerCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<RowVersionResult> Handle(UpdatePhysicalAccountOpenRequestByReviewerCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(command.Guid);
        var entity = await GetUpdatedPhysicalEntityForReviewer(command.Guid, command.Payload, cancellationToken);

        _mapper.Map(command.Payload, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new RowVersionResult(entity);
    }
}
