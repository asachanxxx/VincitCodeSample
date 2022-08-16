using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetUser;

[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record GetUserQuery : IRequest<UserDto>
{
    public GetUserQuery(Guid guid)
    {
        Guid = guid;
    }

    public Guid Guid
    {
        get;
    }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking()
            .Include(u => u.Role)
            .ThenInclude(r => r.ApplicationRoleBPermissions)
            .ThenInclude(rp => rp.Permission)
            .Where(u => u.UserGraphId == request.Guid)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken);
    }
}