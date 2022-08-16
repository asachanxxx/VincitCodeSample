using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Common.Queries;

public record GetActiveUserPicklistItemsQuery : IRequest<IEnumerable<UserPicklistItemDto>>
{
    public GetActiveUserPicklistItemsQuery(UserPicklistTypeEnum type)
    {
        Type = type;
    }

    public UserPicklistTypeEnum Type
    {
        get; private set;
    }
}

public class GetActiveUserPicklistItemsQueryHandler : IRequestHandler<GetActiveUserPicklistItemsQuery, IEnumerable<UserPicklistItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActiveUserPicklistItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserPicklistItemDto>> Handle(GetActiveUserPicklistItemsQuery request, CancellationToken cancellationToken)
    {
        switch (request.Type.Name)
        {
            case nameof(UserPicklistTypeEnum.Reconciler):
            case nameof(UserPicklistTypeEnum.ReconciliationReviewer):
                return await _context.Users.AsNoTracking()
                    .Include(u => u.Role)
                    .Where(u => u.IsActive && (u.Role.ApplicationRoleCode == ApplicationRoleEnum.BankAdmin || u.Role.ApplicationRoleCode == ApplicationRoleEnum.GeneralAccounting))
                    .OrderBy(u => u.Name)
                    .ProjectTo<UserPicklistItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            default:
                throw new NotFoundException("User Picklist Type is not found.", request.Type.Name);
        }
    }
}
