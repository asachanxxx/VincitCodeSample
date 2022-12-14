using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class PvBaseAccountRegister : AccountRegister
    {
        public PvBaseAccountRegister()
        {
            AccountType = default!;
            ClientName = default!;
            ClientRef = default!;
            PropertyName = default!;
            PrefferedCashbookID = default!;
            TenancyReferenceNumber = default!;
            TrampsCashbookId = default!;
            BankRe1 = default!;
            BankRe2 = default!;
            AmountOfOpeninigBalanceMovedToAccount = default!;
            RejectReason = default!;
            DepositLetterTenantRef = default!;
            ReconciliationFrequency = default!;
            TenantName = default!;
            BankID = default!;
            BankAccountName = default!;
            AccountGroup = default!;
        }

        public int? CurrencyID
        {
            get; set;
        }

        public virtual Currency? Currency
        {
            get; set;
        }

        public string? ClientRef
        {
            get; set;
        }

        public int? AccountTypeID
        {
            get; set;
        }

        public virtual AccountType? AccountType
        {
            get; set;
        }

        public string? PropertyName
        {
            get; set;
        }

        public string? PrefferedCashbookID
        {
            get; set;
        }

        public string? TenancyReferenceNumber
        {
            get; set;
        }

        public decimal? Amount
        {
            get; set;
        }

        public DateTime? DateReceived
        {
            get; set;
        }

        public int? BankReconciliationsToBePreparedById
        {
            get; set;
        }

        public virtual User? BankReconciliationsToBePreparedByUser
        {
            get; set;
        }

        public int? BankReconciliationsToBeReviewedById
        {
            get; set;
        }

        public virtual User? BankReconciliationsToBeReviewedByUser
        {
            get; set;
        }

        public string? TrampsCashbookId
        {
            get; set;
        }

        public string? BankRe1
        {
            get; set;
        }

        public string? BankRe2
        {
            get; set;
        }

        public DateTime? DateOpened
        {
            get; set;
        }

        public decimal? AmountOfOpeninigBalanceMovedToAccount
        {
            get; set;
        }

        public DateTime? DateAmountOfOpeningBalanceMovedIntoAccount
        {
            get; set;
        }

        public DateTime? DateRegisterEntryCompleted
        {
            get; set;
        }

        public string? DepositLetterTenantRef
        {
            get; set;
        }

        public DateTime? DepositLetterLastLetterSent
        {
            get; set;
        }

        public string? RejectReason
        {
            get; set;
        }

        public string? Notes
        {
            get; set;
        }

        public string? ReconciliationFrequency
        {
            get; set;
        }

        public string? TenantName
        {
            get; set;
        }

        public string? BankID
        {
            get; set;
        }

        public DateTime? DateSetupOnDatabase
        {
            get; set;
        }

        public string? BankAccountName
        {
            get; set;
        }

        public string? AccountGroup
        {
            get; set;
        }

        public DateTime? AccountGroupUpdatedOn
        {
            get; set;
        }

        public string? PhysicalBankAdminSortCode
        {
            get; set;
        }

        public string? AnyOtherInformation
        {
            get; set;
        }
    }
}