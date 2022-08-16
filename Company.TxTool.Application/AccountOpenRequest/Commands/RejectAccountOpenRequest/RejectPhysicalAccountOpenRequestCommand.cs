using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.RejectAccountOpenRequest
{
    [AuthorizeForPermission(PermissionEnum.AorApproveReject)]
    public class RejectPhysicalAccountOpenRequestCommand : IRequest<RowVersionResult>
    {
        public RejectPhysicalAccountOpenRequestCommand(Guid guid, PhysicalAccountOpenRequestReviewerSectionDto payload)
        {
            Guid = guid;
            Payload = payload;
        }

        public Guid Guid
        {
            get;
        }

        public PhysicalAccountOpenRequestReviewerSectionDto Payload
        {
            get;
        }
    }

    public class RejectPhysicalAccountOpenRequestCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<RejectPhysicalAccountOpenRequestCommand, RowVersionResult>
    {
        private readonly IWorkflowFactory _workflowFactory;

        public RejectPhysicalAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, IWorkflowFactory workflowFactory) : base(context, mapper)
        {
            _workflowFactory = workflowFactory;
        }

        public async Task<RowVersionResult> Handle(RejectPhysicalAccountOpenRequestCommand command, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(command.Guid);
            var entity = await GetUpdatedPhysicalEntityForReviewer(command.Guid, command.Payload, cancellationToken);

            entity.Reject(_workflowFactory);

            await _context.SaveChangesAsync(cancellationToken);
            return new RowVersionResult(entity);
        }
    }
}
