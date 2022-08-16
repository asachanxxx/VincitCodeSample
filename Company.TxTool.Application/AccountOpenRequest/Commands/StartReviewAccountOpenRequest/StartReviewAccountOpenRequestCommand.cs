using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.StartReviewAccountOpenRequest
{
    [AuthorizeForPermission(PermissionEnum.AorApproveReject)]
    public class StartReviewAccountOpenRequestCommand : IRequest<RowVersionResult>
    {
        public StartReviewAccountOpenRequestCommand(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class StartReviewAccountOpenRequestCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<StartReviewAccountOpenRequestCommand, RowVersionResult>
    {
        private readonly IWorkflowFactory _workflowFactory;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateService;

        public StartReviewAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService,
            IDateTime dateService, IWorkflowFactory workflowFactory) : base(context, mapper)
        {
            _workflowFactory = workflowFactory;
            _currentUserService = currentUserService;
            _dateService = dateService;
        }

        public async Task<RowVersionResult> Handle(StartReviewAccountOpenRequestCommand command, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(command.Guid);
            var entity = await GetEntity(command.Guid, cancellationToken);
            ThrowIfAlreadyInReview(entity);

            entity.SetupReviewerAndDate(_currentUserService.User.UserID, _dateService.UtcNow);
            if (entity is PvBaseAccountOpenRequest)
            {
                (entity as PvBaseAccountOpenRequest)!.SetupAutoPopulateRulesOnReview();
            }

            entity.StartReview(_workflowFactory);

            await _context.SaveChangesAsync(cancellationToken);
            return new RowVersionResult(entity);
        }

        private static void ThrowIfAlreadyInReview(BaseAccountOpenRequest entity)
        {
            if (entity.Status == AccountOpenRequestStatusEnum.InReview)
            {
                throw new RequestAlreadyInReviewException();
            }
        }
    }
}