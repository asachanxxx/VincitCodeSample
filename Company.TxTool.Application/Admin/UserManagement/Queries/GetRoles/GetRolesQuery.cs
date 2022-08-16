using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetRoles;

[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record GetApplicationRolesQuery : IRequest<IEnumerable<ApplicationRoleDto>>
{
}

public class GetRolesQueryQueryHandler : IRequestHandler<GetApplicationRolesQuery, IEnumerable<ApplicationRoleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRolesQueryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ApplicationRoleDto>> Handle(GetApplicationRolesQuery request, CancellationToken cancellationToken)
    {
        return await _context.ApplicationRoles.AsNoTracking()
            .Where(r => r.IsStandardRole && r.IsActive)
            .ProjectTo<ApplicationRoleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}