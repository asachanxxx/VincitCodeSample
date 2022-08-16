using System;

namespace Cushwake.TreasuryTool.Domain.Reconciliation
{
    public interface IReconciliationDateStrategy
    {
        DateTimeOffset CalculateNextDate(DateTimeOffset startDate, ReconciliationSchedule schedule);
    }
}
