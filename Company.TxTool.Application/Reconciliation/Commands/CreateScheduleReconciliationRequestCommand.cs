using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Reconciliation.Commands
{
    public record CreateScheduleReconciliationRequestCommand : IRequest<Unit>
    {
        public CreateScheduleReconciliationRequestCommand()
        {
        }

        public DateTime ScheduleDate
        {
            get; set;
        }
    }

    public class CreateScheduleReconciliationRequestCommandHandler : IRequestHandler<CreateScheduleReconciliationRequestCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IDateTime _datetimeService;
        private readonly IReconciliationDateStrategy _reconciliationDateStrategy;

        public CreateScheduleReconciliationRequestCommandHandler(IApplicationDbContext context, IStorageService storageService, IDateTime datetimeservice, IReconciliationDateStrategy reconciliationDateStrategy)
        {
            _context = context;
            _storageService = storageService;
            _datetimeService = datetimeservice;
            _reconciliationDateStrategy = reconciliationDateStrategy;
        }

        public async Task<Unit> Handle(CreateScheduleReconciliationRequestCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _context.ReconciliationSchedules.AsNoTracking()
                .Where(d => d.NextReconciliationToBeCreatedOn <= _datetimeService.UtcNow)
                .ToListAsync(cancellationToken);

            foreach (var schedule in schedules)
            {
                //TODO: Create reconciliation entity
                //_context.Reconciliations.Add()

                schedule.CalculateNextReconciliationDate(_datetimeService.UtcNow, _reconciliationDateStrategy);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}