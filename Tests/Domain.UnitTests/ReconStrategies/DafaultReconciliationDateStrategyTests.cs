using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Domain.UnitTests.ReconStrategies
{
    public class DafaultReconciliationDateStrategyTests
    {
        [Test]
        public void CalculateNextDate_CallsForDaily_BeforeTriggerGap_ReturnsNextDay()
        {
            var triggerGap = TimeSpan.FromHours(1);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Daily };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2020, 1, 1, 10, 0, 0), TimeSpan.FromHours(5.5));

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2020, 1, 1, 23, 0, 0));
        }

        [Test]
        public void CalculateNextDate_CallsForDaily_AfterTriggerGap_ReturnsDayAfterNextDay()
        {
            var triggerGap = TimeSpan.FromHours(1);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Daily };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2020, 1, 1, 23, 30, 0), TimeSpan.FromHours(5.5));

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2020, 1, 2, 23, 0, 0));
        }

        [Test]
        public void CalculateNextDate_CallsForWeekly_BeforeTwoDayTriggerGap_ReturnsWeekDay()
        {
            var triggerGap = TimeSpan.FromDays(2);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Weekly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 8, 3, 10, 0, 0), TimeSpan.FromHours(5.5)); // Wednesday

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 8, 6, 0, 0, 0)); // Saturday
        }

        [Test]
        public void CalculateNextDate_CallsForWeekly_AfterTwoDayTriggerGap_ReturnsNextWeekDay()
        {
            var triggerGap = TimeSpan.FromDays(2);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Weekly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 8, 7, 10, 0, 0), TimeSpan.FromHours(5.5)); // Sunday

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 8, 13, 0, 0, 0)); // Next Saturday
        }

        [Test]
        public void CalculateNextDate_CallsForMonthly_BeforeOneWeekTriggerGap_ReturnsMonthDay()
        {
            var triggerGap = TimeSpan.FromDays(7);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Monthly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 8, 3, 10, 0, 0), TimeSpan.FromHours(5.5)); // Day within first few weeks

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 8, 25, 0, 0, 0)); // One week before this month-end
        }

        [Test]
        public void CalculateNextDate_CallsForMonthly_AfterOneWeekTriggerGap_ReturnsNextMonthDay()
        {
            var triggerGap = TimeSpan.FromDays(7);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Monthly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 8, 26, 10, 0, 0), TimeSpan.FromHours(5.5)); // Day within last week

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 9, 24, 0, 0, 0)); // One week before next month-end
        }

        [Test]
        public void CalculateNextDate_CallsForQuarterly_BeforeOneMonthTriggerGap_ReturnsQuarterDay()
        {
            var triggerGap = TimeSpan.FromDays(30);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Quarterly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 8, 3, 10, 0, 0), TimeSpan.FromHours(5.5)); // Day within first two months of the quarter

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 9, 1, 0, 0, 0)); // 30 days before this quarter-end
        }

        [Test]
        public void CalculateNextDate_CallsForQuarterly_AfterOneWeekTriggerGap_ReturnsNextQuarterDay()
        {
            var triggerGap = TimeSpan.FromDays(30);
            var sut = new DafaultReconciliationDateStrategy();
            var schedule = new ReconciliationSchedule { Frequency = ReconciliationFrequencyEnum.Quarterly };
            schedule.TriggerGapBeforeEvent = triggerGap;
            var startDate = new DateTimeOffset(new DateTime(2022, 9, 3, 10, 0, 0), TimeSpan.FromHours(5.5)); // Day within last month of the quarter

            DateTimeOffset result = sut.CalculateNextDate(startDate, schedule);

            result.DateTime.Should().Be(new DateTime(2022, 12, 2, 0, 0, 0)); // 30 days before next quarter-end
        }
    }
}