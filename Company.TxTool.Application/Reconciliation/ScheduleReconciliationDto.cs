using System;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Company.TxTool.Application.Reconciliation
{
    public class ScheduleReconciliationDto : IMapFrom<Domain.Reconciliation.ReconciliationSchedule>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public ScheduleReconciliationDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public virtual AccountRegister AccountRegister
        {
            get; set;
        }

        public ReconciliationFrequencyEnum Frequency
        {
            get; set;
        }

        public DateTime NextReconciliationToBeCreatedOn
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }
    }
}