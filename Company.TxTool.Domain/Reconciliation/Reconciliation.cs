using System;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Reconciliation
{
    public class Reconciliation : BaseAuditableEntity, IBelongToTenant
    {
        public Reconciliation()
        {
            AccountRegister = default!;
            Type = default!;
            PreparedBy = default!;
            ReviewedBy = default!;
            OriginFrequency = default!;
        }

        public AccountRegister.AccountRegister AccountRegister
        {
            get; set;
        }

        public ReconciliationTypeEnum Type
        {
            get; private set;
        }

        public ReconciliationFrequencyEnum OriginFrequency
        {
            get; set;
        }

        public DateTime DeadlineDate
        {
            get; set;
        }

        public User PreparedBy
        {
            get; set;
        }

        public User ReviewedBy
        {
            get; set;
        }
    }
}
