using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.UserManagement.Queries.GetUsers;
/*
 ToDo : Removed pagination temporery. well be implemented later
 */
[AuthorizeForPermission(PermissionEnum.AdminUserMgt)]
public record GetUsersPaginatedQuery : IRequest<IEnumerable<UserListItemDto>>
{
}

public class GetUserListQueryHandler : IRequestHandler<GetUsersPaginatedQuery, IEnumerable<UserListItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserListItemDto>> Handle(GetUsersPaginatedQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking()
            .Include(x => x.Role)
            .OrderBy(x => x.Name)
            .ProjectTo<UserListItemDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        //.PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}