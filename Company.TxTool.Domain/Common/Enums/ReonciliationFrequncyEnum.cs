using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Common.Enums
{
    public abstract class ReconciliationFrequencyEnum : SmartEnum<ReconciliationFrequencyEnum>
    {
        protected ReconciliationFrequencyEnum(string name, int value) : base(name, value)
        {
        }

        public static readonly ReconciliationFrequencyEnum Daily = new DailyReconciliation();
        public static readonly ReconciliationFrequencyEnum Weekly = new WeeklyReconciliation();
        public static readonly ReconciliationFrequencyEnum Monthly = new MonthlyReconciliation();
        public static readonly ReconciliationFrequencyEnum Quarterly = new QuarterlyReconciliation();

        public abstract TimeSpan TriggerGapBeforeEvent
        {
            get;
        }

        public abstract TimeSpan DeadlineAfterEvent
        {
            get;
        }

        protected DateTime GetNextQuarterDay(DateTime start, int dayOfQuarter)
        {
            int currentQuarterNumber = (start.Month - 1) / 3 + 1;
            DateTime dayOfCurrentQuarter = new DateTime(start.Year, (currentQuarterNumber - 1) * 3 + 1, dayOfQuarter);
            return dayOfCurrentQuarter.AddMonths(3);
        }

        protected DateTime GetNextMonthDay(DateTime start, int dayOfMonth)
        {
            return new DateTime(start.AddMonths(1).Year, start.AddMonths(1).Month, dayOfMonth);
        }

        protected static DateTime GetNextDay(DateTime start)
        {
            return start.Date.AddDays(1);
        }

        protected static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            start = GetNextDay(start);
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        public abstract DateTime GetNextDate(DateTime currentDate);

        private sealed class DailyReconciliation : ReconciliationFrequencyEnum
        {
            public DailyReconciliation() : base("Daily", 1)
            {
            }

            public override TimeSpan TriggerGapBeforeEvent => TimeSpan.Zero;
            public override TimeSpan DeadlineAfterEvent => TimeSpan.FromDays(2);

            public override DateTime GetNextDate(DateTime startDate) => GetNextDay(startDate);
        }

        private sealed class WeeklyReconciliation : ReconciliationFrequencyEnum
        {
            public WeeklyReconciliation() : base("Weekly", 2)
            {
            }

            public override TimeSpan TriggerGapBeforeEvent => TimeSpan.FromDays(2);
            public override TimeSpan DeadlineAfterEvent => TimeSpan.FromDays(5);

            public override DateTime GetNextDate(DateTime startDate) => GetNextWeekday(startDate.Date, DayOfWeek.Monday);
        }

        private sealed class MonthlyReconciliation : ReconciliationFrequencyEnum
        {
            public MonthlyReconciliation() : base("Monthly", 3)
            {
            }

            public override TimeSpan TriggerGapBeforeEvent => TimeSpan.FromDays(7);
            public override TimeSpan DeadlineAfterEvent => TimeSpan.FromDays(14);

            public override DateTime GetNextDate(DateTime startDate) => GetNextMonthDay(startDate.Date, 1);
        }

        private sealed class QuarterlyReconciliation : ReconciliationFrequencyEnum
        {
            public QuarterlyReconciliation() : base("Quarterly", 4)
            {
            }

            public override TimeSpan TriggerGapBeforeEvent => TimeSpan.FromDays(14);
            public override TimeSpan DeadlineAfterEvent => TimeSpan.FromDays(30);

            public override DateTime GetNextDate(DateTime startDate) => GetNextQuarterDay(startDate.Date, 1);
        }
    }
}
