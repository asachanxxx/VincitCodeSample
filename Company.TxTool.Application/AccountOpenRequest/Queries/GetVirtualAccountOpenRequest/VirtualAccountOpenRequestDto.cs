using AutoMapper;
using Company.TxTool.Application.AccountOpenRequest.Queries.Common;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetVirtualAccountOpenRequest
{
    public class VirtualAccountOpenRequestDto : BaseAccountOpenRequestDto, IMapFrom<VirtualAccountOpenRequest>
    {
        public VirtualAccountOpenRequestDto()
        {
            RequestedBy = default!;
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

        public string? ClientName
        {
            get; set;
        }

        public string? ClientRef
        {
            get; set;
        }

        public string? ReconciliationFrequency
        {
            get; set;
        }

        public string? PrefferedCashbookID
        {
            get; set;
        }

        public string? TenantName
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

        public decimal? Amount
        {
            get; set;
        }

        public DateTime? DateReceived
        {
            get; set;
        }

        public int? BankID
        {
            get; set;
        }

        public string? AnyOtherInformation
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VirtualAccountOpenRequest, VirtualAccountOpenRequestDto>()
                .ForMember(d => d.RequestedBy, opt => opt.MapFrom(s => s.RequestedUser.NameAndEmail))
                .ForMember(d => d.RequestedById, opt => opt.MapFrom(s => s.RequestedBy))
                .ForMember(d => d.ReviewedBy, opt => opt.MapFrom(s => s.ReviewedUser.NameAndEmail))
                .ForMember(d => d.ReviewedById, opt => opt.MapFrom(s => s.ReviewedBy))
                .ForMember(d => d.BankReconciliationsToBePreparedBy, opt => opt.MapFrom(s => s.BankReconciliationsToBePreparedByUser))
                .ForMember(d => d.BankReconciliationsToBeReviewedBy, opt => opt.MapFrom(s => s.BankReconciliationsToBeReviewedByUser));
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
    }
}