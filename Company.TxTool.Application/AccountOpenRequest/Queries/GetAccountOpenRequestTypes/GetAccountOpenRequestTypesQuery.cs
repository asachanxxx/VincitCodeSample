using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetAccountOpenRequestTypes
{
    [AuthorizeForPermission(PermissionEnum.AorCreateNew)]
    public class GetAccountOpenRequestTypesQuery : IRequest<IEnumerable<AccountOpenRequestTypeDto>>
    {
    }

    public class GetAccountOpenRequestTypesQueryHandler : IRequestHandler<GetAccountOpenRequestTypesQuery, IEnumerable<AccountOpenRequestTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountOpenRequestTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountOpenRequestTypeDto>> Handle(GetAccountOpenRequestTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.AccountOpenRequestTypes.AsNoTracking()
                .ProjectTo<AccountOpenRequestTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}