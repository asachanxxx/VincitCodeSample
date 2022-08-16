using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetRoles;

public class ApplicationRoleDto : IMapFrom<ApplicationRole>
{
    public ApplicationRoleDto()
    {
        ApplicationRoleCode = default!;
    }

    public int ApplicationRoleID
    {
        get; set;
    }

    public string ApplicationRoleCode
    {
        get; set;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicationRole, ApplicationRoleDto>()
            .ForMember(d => d.ApplicationRoleID, opt => opt.MapFrom(s => s.Id));
    }
}