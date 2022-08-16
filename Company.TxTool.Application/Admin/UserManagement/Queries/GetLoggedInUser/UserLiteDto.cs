using AutoMapper;
using Company.TxTool.Application.Common.Mappings;
using Cushwake.TreasuryTool.Domain.Security;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetLoggedInUser
{
    public class UserLiteDto : IMapFrom<UserLite>
    {
        public UserLiteDto()
        {
            Guid = default!;
            Name = default!;
            Email = default!;
            TenantCode = default!;
            TenantCultureCode = default!;
            Role = default!;
            Permissions = default!;
        }

        public int Id
        {
            get; set;
        }

        public Guid Guid
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string TenantCode
        {
            get; set;
        }

        public string TenantCultureCode
        {
            get; set;
        }

        public string Role
        {
            get; set;
        }

        public IEnumerable<string> Permissions
        {
            get; set;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLite, UserLiteDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserID))
                .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.UserGraphID))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.WorkEmail))
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role));
        }
    }
}
