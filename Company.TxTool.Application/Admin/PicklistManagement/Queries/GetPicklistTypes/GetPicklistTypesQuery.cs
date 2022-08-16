using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.Admin.PicklistManagement.Queries.GetPicklistTypes
{
    [AuthorizeForPermission(PermissionEnum.AdminPicklistMgt)]
    public record GetPicklistTypesQuery : IRequest<IEnumerable<PicklistTypeDto>>
    {
    }

    public class GetPicklistsQueryHandler : IRequestHandler<GetPicklistTypesQuery, IEnumerable<PicklistTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPicklistsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PicklistTypeDto>> Handle(GetPicklistTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.PicklistTypes.AsNoTracking()
                .ProjectTo<PicklistTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}