using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetRolePermissions;

[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record GetRolePermissionsQuery : IRequest<IEnumerable<PermissionDto>>
{
    public GetRolePermissionsQuery(int roleId)
    {
        RoleId = roleId;
    }

    public int RoleId
    {
        get; private set;
    }
}

public class PermissionQueryHandler : IRequestHandler<GetRolePermissionsQuery, IEnumerable<PermissionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PermissionDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ApplicationRoles.AsNoTracking()
             .Include(r => r.ApplicationRoleBPermissions)
             .ThenInclude(rp => rp.Permission)
             .Where(r => r.Id == request.RoleId)
             .SelectMany(r => r.ApplicationRoleBPermissions)
             .OrderBy(rp => rp.Permission.MemberOrderKey)
             .ProjectTo<PermissionDto>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
    }
}