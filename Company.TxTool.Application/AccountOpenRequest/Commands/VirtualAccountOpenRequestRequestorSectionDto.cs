using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.AccountOpenRequest.Commands
{
    public class VirtualAccountOpenRequestRequestorSectionDto : IMapFrom<VirtualAccountOpenRequest>
    {
        public VirtualAccountOpenRequestRequestorSectionDto()
        {
            ClientRef = default!;
            PropertyName = default!;
            PrefferedCashbookID = default!;
            TenancyReferenceNumber = default!;
            BankRe1 = default!;
            BankRe2 = default!;
            AmountOfOpeninigBalanceMovedToAccount = default!;
            DepositLetterTenantRef = default!;
            ClientName = default!;
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

        public int? DatabaseTypeID
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

        public int? BankReconciliationsToBeReviewedById
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

        public int? BankID
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

        public string? ClientName
        {
            get; set;
        }

        public DateTime? DateOpened
        {
            get; set;
        }

        public string? PhysicalBankAdminSortCode
        {
            get; set;
        }

        public string? PostingRulesInBMAPDebtorClientRef
        {
            get; set;
        }

        public string? TransactionTypeCode
        {
            get; set;
        }

        public string? PropertyNumber
        {
            get; set;
        }

        public string? ExpenseCode
        {
            get; set;
        }

        public string? ScheduleRef
        {
            get; set;
        }

        public string? ChartCode
        {
            get; set;
        }

        public string? VirtualAccountNumber
        {
            get; set;
        }

        public string? AnyOtherInformation
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VirtualAccountOpenRequestRequestorSectionDto, VirtualAccountOpenRequest>();
        }
    }
}