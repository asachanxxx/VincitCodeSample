using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequests
{
    [AuthorizeForPermission(PermissionEnum.AorViewList)]
    public record GetAccountOpenRequestsPaginatedQuery : IRequest<List<AccountOpenRequestListItemDto>>
    {
    }

    public class GetAccountOpenRequestsPaginatedQueryHandler : IRequestHandler<GetAccountOpenRequestsPaginatedQuery, List<AccountOpenRequestListItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountOpenRequestsPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AccountOpenRequestListItemDto>> Handle(GetAccountOpenRequestsPaginatedQuery request, CancellationToken cancellationToken)
        {
            return await _context.AccountOpenRequests.AsNoTracking()
              .Include(x => x.RequestedUser)
              .Include(x => x.ReviewedUser)
              .Include(x => x.DatabaseType)
              .OrderByDescending(x => x.Created).ThenByDescending(x => x.Modified)
              .ProjectTo<AccountOpenRequestListItemDto>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);
            //.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
