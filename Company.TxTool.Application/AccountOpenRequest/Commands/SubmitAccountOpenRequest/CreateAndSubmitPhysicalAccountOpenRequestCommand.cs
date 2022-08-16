using System;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.SubmitAccountOpenRequest
{
    public record CreateAndSubmitPhysicalAccountOpenRequestCommand : BaseSubmitPhysicalAccountOpenRequestCommand, IRequest<RowVersionResult>
    {
        public CreateAndSubmitPhysicalAccountOpenRequestCommand(PhysicalAccountOpenRequestRequestorSectionDto payload) : base(payload)
        {
        }
    }

    public class CreateAndSubmitPhysicalAccountOpenRequestCommandHandler : IRequestHandler<CreateAndSubmitPhysicalAccountOpenRequestCommand, RowVersionResult>
    {
        private readonly IApplicationDbContext _context;
        public readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateService;
        private readonly IWorkflowFactory _workflowFactory;

        public CreateAndSubmitPhysicalAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IDateTime dateService, IWorkflowFactory workflowFactory)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _dateService = dateService;
            _workflowFactory = workflowFactory;
        }

        public async Task<RowVersionResult> Handle(CreateAndSubmitPhysicalAccountOpenRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = new PhysicalAccountOpenRequest(_currentUserService.User.UserID, _dateService.TenantLocalToday);
            _mapper.Map(command.Payload, entity);

            entity.SetupRequestedDate(_dateService.UtcNow);
            entity.Submit(_workflowFactory);

            _context.AccountOpenRequests.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new RowVersionResult(entity);
        }
    }
}
