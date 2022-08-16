using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetUsers;

public class UserListItemDto : IMapFrom<User>
{
    public UserListItemDto()
    {
        Name = default!;
        WorkEmail = default!;
        ApplicationRoleCode = default!;
    }

    public Guid Guid
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public string WorkEmail
    {
        get; set;
    }

    public string ApplicationRoleCode
    {
        get; set;
    }

    public bool IsActive
    {
        get; set;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserListItemDto>()
            .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.UserGraphId))
            .ForMember(d => d.ApplicationRoleCode, opt => opt.MapFrom(s => s.Role.ApplicationRoleCode));
    }
}