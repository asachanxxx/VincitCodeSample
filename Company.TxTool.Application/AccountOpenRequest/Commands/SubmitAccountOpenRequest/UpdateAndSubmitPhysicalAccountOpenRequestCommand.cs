using System;
using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Commands;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Common.Models;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using MediatR;

namespace Company.TxTool.Application.AccountOpenRequest.Commands.SubmitAccountOpenRequest
{
    public record UpdateAndSubmitPhysicalAccountOpenRequestCommand : BaseSubmitPhysicalAccountOpenRequestCommand, IRequest<RowVersionResult>
    {
        public UpdateAndSubmitPhysicalAccountOpenRequestCommand(Guid guid, PhysicalAccountOpenRequestRequestorSectionDto payload) : base(payload)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class UpdateAndSubmitPhysicalAccountOpenRequestCommandHandler : BaseAccountOpenRequestCommandHandler, IRequestHandler<UpdateAndSubmitPhysicalAccountOpenRequestCommand, RowVersionResult>
    {
        private readonly IWorkflowFactory _workflowFactory;
        private readonly IDateTime _dateService;

        public UpdateAndSubmitPhysicalAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper, IWorkflowFactory workflowFactory, IDateTime dateService) : base(context, mapper)
        {
            _workflowFactory = workflowFactory;
            _dateService = dateService;
        }

        public async Task<RowVersionResult> Handle(UpdateAndSubmitPhysicalAccountOpenRequestCommand command, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(command.Guid);
            var entity = await GetUpdatedPhysicalEntityForRequestor(command.Guid, command.Payload, cancellationToken);

            entity.SetupRequestedDate(_dateService.UtcNow);
            entity.Submit(_workflowFactory);
            await _context.SaveChangesAsync(cancellationToken);

            return new RowVersionResult(entity);
        }
    }
}
