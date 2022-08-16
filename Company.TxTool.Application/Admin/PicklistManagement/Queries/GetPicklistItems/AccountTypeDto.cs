using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Picklist;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistItems
{
    public class AccountTypeDto : PicklistItemDto, IMapFrom<AccountType>
    {
        public AccountTypeDto()
        {
            ReconciliationFrequency = default!;
        }

        public string ReconciliationFrequency
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountType, AccountTypeDto>()
                .ForMember(d => d.ReconciliationFrequency, opt => opt.MapFrom(s => s.ReconciliationFrequency.Name ?? string.Empty));
        }
    }
}