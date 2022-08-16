using System;

namespace Cushwake.TreasuryTool.Domain.Reconciliation
{
    public class BaseReconciliationDateStrategy
    {
        protected BaseReconciliationDateStrategy()
        {
        }

        protected DateTime GetRawTriggerLocalDate(DateTimeOffset startDate, ReconciliationSchedule schedule)
        {


            DateTimeOffset gapAdjustedStartDate = GetGapAdjustedStartDate(startDate, schedule);
            return schedule.Frequency.GetNextDate(gapAdjustedStartDate.Date);
        }

        private static DateTimeOffset GetGapAdjustedStartDate(DateTimeOffset startDate, ReconciliationSchedule schedule)
        {
            // This is done to avoid creating reconciliations which have already passed.
            // For example, if the frequency is weekly and the trigger gap is 2 days, effectively setting it for fridays
            // if you create the account register on a saturday, you will get the next raw date as monday then next reconciliation date would be friday
            // which has already passed. When you advance the start date by the gap, you run the schedular as if you are running it on monday (2 days from saturday)
            // without triggering false reconociliations.
            return new DateTimeOffset(startDate.DateTime.Add(schedule.TriggerGapBeforeEvent), startDate.Offset);
        }
    }

    public class DafaultReconciliationDateStrategy : BaseReconciliationDateStrategy, IReconciliationDateStrategy
    {
        public DateTimeOffset CalculateNextDate(DateTimeOffset startDate, ReconciliationSchedule schedule)
        {
            var rawTriggerDate = GetRawTriggerLocalDate(startDate, schedule);
            var actualTriggerDate = rawTriggerDate.Subtract(schedule.TriggerGapBeforeEvent);
            return new DateTimeOffset(actualTriggerDate, startDate.Offset);
        }
    }
}
