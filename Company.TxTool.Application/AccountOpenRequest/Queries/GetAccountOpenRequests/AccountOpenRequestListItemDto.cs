using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequests
{
    public class AccountOpenRequestListItemDto : IMapFrom<BaseAccountOpenRequest>
    {
        public AccountOpenRequestListItemDto()
        {
            ClientName = default!;
            DatabaseType = default!;
            Requestor = default!;
            Reviewer = default!;
            Status = default!;
            Type = default!;
        }

        public Guid Guid
        {
            get; set;
        }

        public string ClientName
        {
            get; set;
        }

        public string DatabaseType
        {
            get; set;
        }

        public string Requestor
        {
            get; set;
        }

        public string? Reviewer
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }

        public DateTime? RequestedOn
        {
            get; set;
        }

        public DateTime? ReviewedOn
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaseAccountOpenRequest, AccountOpenRequestListItemDto>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Requestor, opt => opt.MapFrom(s => s.RequestedUser.Name))
                .ForMember(d => d.Reviewer, opt => opt.MapFrom(s => s.ReviewedUser.Name))
                .ForMember(d => d.DatabaseType, opt => opt.MapFrom(s => s.DatabaseType.Name));
        }
    }
}
