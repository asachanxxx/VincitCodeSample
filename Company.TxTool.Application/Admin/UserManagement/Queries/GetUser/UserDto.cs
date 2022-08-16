using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetUser
{
    public class UserDto : IMapFrom<User>
    {
        public UserDto()
        {
            Name = default!;
            FirstName = default!;
            LastName = default!;
            WorkEmail = default!;
            ApplicationRoleCode = default!;
            RowVersion = default!;
            Permissions = default!;
        }

        public int UserID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string WorkEmail
        {
            get; set;
        }

        public int ApplicationRoleID
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

        public byte[] RowVersion
        {
            get; set;
        }

        public IList<UserPermissionDto> Permissions
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserID, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.ApplicationRoleCode, opt => opt.MapFrom(s => s.Role.ApplicationRoleCode))
                .ForMember(d => d.Permissions, opt => opt.MapFrom(s => s.Role.ApplicationRoleBPermissions));
        }

        public class UserPermissionDto : IMapFrom<ApplicationRoleBPermission>
        {
            public UserPermissionDto()
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

            public void Mapping(Profile profile)
            {
                profile.CreateMap<ApplicationRoleBPermission, UserPermissionDto>()
                    .ForMember(d => d.PermissionID, opt => opt.MapFrom(s => s.PermissionId))
                    .ForMember(d => d.PermissionCode, opt => opt.MapFrom(s => s.Permission.PermissionCode));
            }
        }
    }
}