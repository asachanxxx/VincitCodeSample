using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetRolePermissions;

public class PermissionDto : IMapFrom<ApplicationRoleBPermission>
{
    public PermissionDto()
    {
        PermissionCode = default!;
    }

    public int PermissionID
    {
        get; set;
    }

    public string PermissionCode
    {
        get; set;
    }

    public bool IsDefault
    {
        get; set;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicationRoleBPermission, PermissionDto>()
            .ForMember(d => d.PermissionID, opt => opt.MapFrom(s => s.PermissionId))
            .ForMember(d => d.IsDefault, opt => opt.MapFrom(s => s.IsDefault))
            .ForMember(d => d.PermissionCode, opt => opt.MapFrom(s => s.Permission.PermissionCode));
    }
}