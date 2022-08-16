using System;
using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Company.TxTool.Application.Extensions;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.AccountOpenRequest.Commands
{
    public class PhysicalAccountOpenRequestReviewerSectionDto : IMapFrom<PhysicalAccountOpenRequest>
    {
        public PhysicalAccountOpenRequestReviewerSectionDto()
        {
            PayingInBooksToGoTo = default!;
            AccountNumber = default!;
            TrampsCashbookId = default!;
            BankRe1 = default!;
            AmountOfOpeninigBalanceMovedToAccount = default!;
            DepositLetterTenantRef = default!;
            BankAccountName = default!;
            AccountGroup = default!;
            RowVersion = default!;
            RejectReason = default!;
            LetterSentToBank = new List<int>();
            DepositLetters = new List<int>();
        }

        public string? TrampsCashbookId
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

        public string? BankRe1
        {
            get; set;
        }

        public DateTime? DateOpened
        {
            get; set;
        }

        public string? AccountGroup
        {
            get; set;
        }

        public string? PayingInBooksToGoTo
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

        public DateTime? AccountGroupUpdatedOn
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

        public string? Notes
        {
            get; set;
        }

        public string? PhysicalBankAdminSortCode
        {
            get; set;
        }

        public string? AccountNumber
        {
            get; set;
        }

        public byte[] RowVersion
        {
            get; set;
        }

        public List<int> LetterSentToBank
        {
            get; set;
        }

        public List<int> DepositLetters
        {
            get; set;
        }

        public string RejectReason
        {
            get; set;
        }

        public int? BankID
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhysicalAccountOpenRequestReviewerSectionDto, PhysicalAccountOpenRequest>()
                .ForMember(dest => dest.LettersToBanks, opt => opt.Ignore())
                .ForMember(dest => dest.DepositLetters, opt => opt.Ignore())
                .AfterMap(AddOrUpdateCollections);
        }

        private void AddOrUpdateCollections(PhysicalAccountOpenRequestReviewerSectionDto dto, PhysicalAccountOpenRequest entity)
        {
            entity.LettersToBanks.Sync(dto.LetterSentToBank, e => e.SupportDocumentId, id => new AccountOpenRequestBLetterToBank(id));
            entity.DepositLetters.Sync(dto.DepositLetters, e => e.SupportDocumentId, id => new AccountOpenRequestBDepositLetter(id));
        }
    }
}