using System;
using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Company.TxTool.Application.Extensions;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.AccountOpenRequest.Commands
{
    public class PhysicalAccountOpenRequestRequestorSectionDto : IMapFrom<PhysicalAccountOpenRequest>
    {
        public PhysicalAccountOpenRequestRequestorSectionDto()
        {
            ClientRef = default!;
            PropertyName = default!;
            PrefferedCashbookID = default!;
            TenancyReferenceNumber = default!;
            PayingInBooksToGoTo = default!;
            SortCode = default!;
            AccountNumber = default!;
            ClientName = default!;
            ReconciliationFrequency = default!;
            TenantName = default!;
            BankID = default!;
            SupportingDocumentation = new List<int>();
        }

        public string? AccountNumber
        {
            get; set;
        }

        public string? SortCode
        {
            get; set;
        }

        public int? DatabaseTypeID
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

        public int? CurrencyID
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

        public string? ReconciliationFrequency
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

        public string? TenantName
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

        public int? BankReconciliationsToBePreparedById
        {
            get; set;
        }

        public int? BankReconciliationsToBeReviewedById
        {
            get; set;
        }

        public string? PayingInBooksToGoTo
        {
            get; set;
        }

        public string? AnyOtherInformation
        {
            get; set;
        }

        public List<int> SupportingDocumentation
        {
            get; set;
        }

        public DateTime? AccountGroupUpdatedOn
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhysicalAccountOpenRequestRequestorSectionDto, PhysicalAccountOpenRequest>()
                .ForMember(dest => dest.SupportingDocumentation, opt => opt.Ignore())
                .AfterMap(AddOrUpdateCollections);
        }

        private void AddOrUpdateCollections(PhysicalAccountOpenRequestRequestorSectionDto dto, PhysicalAccountOpenRequest entity)
        {
            entity.SupportingDocumentation.Sync(dto.SupportingDocumentation, e => e.SupportDocumentId, id => new AccountOpenRequestBSupportingDocumentation(id));
        }
    }
}