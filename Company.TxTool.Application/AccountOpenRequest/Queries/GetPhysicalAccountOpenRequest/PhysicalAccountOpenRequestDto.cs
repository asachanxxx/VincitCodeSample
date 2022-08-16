using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Queries.Common;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetPhysicalAccountOpenRequest
{
    public class PhysicalAccountOpenRequestDto : BaseAccountOpenRequestDto, IMapFrom<PhysicalAccountOpenRequest>
    {
        public PhysicalAccountOpenRequestDto()
        {
            Documents = default!;
            LetterSentToBanks = default!;
            DepositLetters = default!;
        }

        public string? PropertyName
        {
            get; set;
        }

        public string? TenancyReferenceNumber
        {
            get; set;
        }

        public CurrencyPicklistItemDto? Currency
        {
            get; set;
        }

        public PicklistItemDto? DatabaseType
        {
            get; set;
        }

        public AccountTypePicklistItemDto? AccountType
        {
            get; set;
        }

        public UserPicklistItemDto? BankReconciliationsToBePreparedBy
        {
            get; set;
        }

        public UserPicklistItemDto? BankReconciliationsToBeReviewedBy
        {
            get; set;
        }

        public virtual Bank? Bank
        {
            get; set;
        }

        public string? PayingInBooksToGoTo

        {
            get; set;
        }

        public string? SortCode
        {
            get; set;
        }

        public string? AccountNumber
        {
            get; set;
        }

        public string? ClientRef
        {
            get; set;
        }

        public string? PrefferedCashbookID
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

        public string? OpeningBalance
        {
            get; set;
        }

        public string? Reconciliations
        {
            get; set;
        }

        public string? AnyOtherInformation
        {
            get; set;
        }

        public DateTime? DateSetupOnTramps
        {
            get; set;
        }

        public string? BankSortCode
        {
            get; set;
        }

        public string? BankNameRe2
        {
            get; set;
        }

        public string? physicalBankAdminSortCode
        {
            get; set;
        }

        public List<SupportDocumentDto> Documents
        {
            get; set;
        }

        public List<SupportDocumentDto> LetterSentToBanks
        {
            get; set;
        }

        public List<SupportDocumentDto> DepositLetters
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhysicalAccountOpenRequest, PhysicalAccountOpenRequestDto>()
                .ForMember(d => d.RequestedBy, opt => opt.MapFrom(s => s.RequestedUser.NameAndEmail))
                .ForMember(d => d.RequestedById, opt => opt.MapFrom(s => s.RequestedBy))
                .ForMember(d => d.ReviewedBy, opt => opt.MapFrom(s => s.ReviewedUser.NameAndEmail))
                .ForMember(d => d.ReviewedById, opt => opt.MapFrom(s => s.ReviewedBy))
                .ForMember(d => d.BankReconciliationsToBePreparedBy, opt => opt.MapFrom(s => s.BankReconciliationsToBePreparedByUser))
                .ForMember(d => d.BankReconciliationsToBeReviewedBy, opt => opt.MapFrom(s => s.BankReconciliationsToBeReviewedByUser))
                .ForMember(d => d.Bank, opt => opt.MapFrom(s => s.Bank))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Documents, opt => opt.MapFrom(s => s.SupportingDocumentation.Select(s => s.SupportDocument)))
                .ForMember(d => d.DepositLetters, opt => opt.MapFrom(s => s.DepositLetters.Select(s => s.SupportDocument)))
                .ForMember(d => d.LetterSentToBanks, opt => opt.MapFrom(s => s.LettersToBanks.Select(s => s.SupportDocument)));
        }

        public class PicklistItemDto : IMapFrom<BasePicklistItem>
        {
            public PicklistItemDto()
            {
                Name = default!;
            }

            public int Id
            {
                get; set;
            }

            public string Name
            {
                get; set;
            }
        }

        public class CurrencyPicklistItemDto : PicklistItemDto, IMapFrom<Currency>
        {
            public CurrencyPicklistItemDto()
            {
                Sign = default!;
            }

            public string Sign
            {
                get; set;
            }
        }

        public class AccountTypePicklistItemDto : PicklistItemDto, IMapFrom<AccountType>
        {
            public AccountTypePicklistItemDto()
            {
                ReconciliationFrequency = default!;
            }

            public string ReconciliationFrequency
            {
                get; set;
            }
        }

        public class UserPicklistItemDto : PicklistItemDto, IMapFrom<User>
        {
            public UserPicklistItemDto()
            {
                WorkEmail = default!;
            }

            public string WorkEmail
            {
                get; set;
            }
        }

        public class SupportDocumentDto : IMapFrom<Domain.Common.SupportDocument>
        {
            public SupportDocumentDto()
            {
                FileName = default!;
            }

            public int Id
            {
                get; set;
            }

            public Guid Guid
            {
                get; set;
            }

            public string FileName
            {
                get; set;
            }
        }
    }
}