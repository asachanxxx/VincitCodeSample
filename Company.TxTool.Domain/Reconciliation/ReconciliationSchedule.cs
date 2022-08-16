using System;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Reconciliation
{
    public class ReconciliationSchedule : BaseAuditableEntity, IBelongToTenant
    {
        private ReconciliationFrequencyEnum frequency;

        public ReconciliationSchedule()
        {
            Tenant = default!;
            PreparedBy = default!;
            ReviewedBy = default!;
            AccountRegister = default!;
            frequency = default!;
        }

        public virtual Tenant Tenant
        {
            get; set;
        }

        public virtual AccountRegister.AccountRegister AccountRegister
        {
            get; set;
        }

        public int AccountRegisterId
        {
            get; set;
        }

        public ReconciliationFrequencyEnum Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;

                TriggerGapBeforeEvent = value.TriggerGapBeforeEvent;
                DeadlineAfterEvent = value.DeadlineAfterEvent;
            }
        }

        public TimeSpan TriggerGapBeforeEvent
        {
            get; set;
        }

        public TimeSpan DeadlineAfterEvent
        {
            get; set;
        }

        public virtual User PreparedBy
        {
            get; set;
        }

        public int PreparedById
        {
            get; set;
        }

        public virtual User ReviewedBy
        {
            get; set;
        }

        public virtual int ReviewedById
        {
            get; set;
        }

        public DateTime NextReconciliationToBeCreatedOn
        {
            get; private set;
        }

        public bool IsActive
        {
            get; set;
        }

        public void CalculateNextReconciliationDate(DateTimeOffset startDate, IReconciliationDateStrategy strategy)
        {
            NextReconciliationToBeCreatedOn = strategy.CalculateNextDate(startDate, this).UtcDateTime;
        }
    }
}
