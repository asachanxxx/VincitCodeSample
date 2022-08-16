using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.StartReviewAccountOpenRequest
{
    [AuthorizeForPermission(PermissionEnum.AorApproveReject)]
    public class OverrideReviewAccountOpenRequestCommand : IRequest<RowVersionResult>
    {
        public OverrideReviewAccountOpenRequestCommand(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class OverrideReviewAccountOpenRequestCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<OverrideReviewAccountOpenRequestCommand, RowVersionResult>
    {
        private readonly ICurrentUserService _currentUserService;

        public OverrideReviewAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context, mapper)
        {
            _currentUserService = currentUserService;
        }

        public async Task<RowVersionResult> Handle(OverrideReviewAccountOpenRequestCommand command, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(command.Guid);
            var entity = await GetEntity(command.Guid, cancellationToken);
            ThrowIfNotAlreadyInReview(entity);

            entity.SetupReviewer(_currentUserService.User.UserID);

            await _context.SaveChangesAsync(cancellationToken);
            return new RowVersionResult(entity);
        }

        private static void ThrowIfNotAlreadyInReview(BaseAccountOpenRequest entity)
        {
            if (entity.Status != AccountOpenRequestStatusEnum.InReview)
            {
                throw new RequestAlreadyInReviewException();
            }
        }
    }
}
