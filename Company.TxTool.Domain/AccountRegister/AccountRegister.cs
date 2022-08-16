using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public abstract class AccountRegister : BaseRowVersionedEntity, IBelongToTenant
    {
        protected AccountRegister()
        {
            ClientName = default!;
            DatabaseType = default!;
            Status = default!;
            RequestedUser = default!;
            Type = default!;
            Documents = new List<AccountRegisterBDocumentation>();
            ReconciliationSchedule = default!;
        }

        public Guid Guid
        {
            get; set;
        }

        public DateTime? RequestedOn
        {
            get; set;
        }

        public int RequestedBy
        {
            get; set;
        }

        public virtual User RequestedUser
        {
            get; private set;
        }

        public string? ClientName
        {
            get; set;
        }

        public int? DatabaseTypeID
        {
            get; set;
        }

        public virtual DatabaseType? DatabaseType
        {
            get; set;
        }

        // Although the property says ReviewedOn, it basically captures the review started date
        public DateTime? ReviewedOn
        {
            get; set;
        }

        public int? ReviewedBy
        {
            get; set;
        }

        public virtual User? ReviewedUser
        {
            get; private set;
        }

        public AccountOpenRequestTypeEnum Type
        {
            get; set;
        }

        public AccountRegisterStatusEnum Status
        {
            get; set;
        }

        public virtual ICollection<AccountRegisterBDocumentation> Documents
        {
            get; set;
        }

        public virtual ReconciliationSchedule ReconciliationSchedule
        {
            get; set;
        }

        public int ReconciliationScheduleId
        {
            get; set;
        }
    }
}