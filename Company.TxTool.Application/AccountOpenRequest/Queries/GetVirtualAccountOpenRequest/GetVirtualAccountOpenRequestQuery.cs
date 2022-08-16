using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetVirtualAccountOpenRequest
{
    [AuthorizeForGeneralAccounting]
    [AuthorizeForBankAdmin]
    public record GetVirtualAccountOpenRequestQuery : IRequest<VirtualAccountOpenRequestDto>
    {
        public GetVirtualAccountOpenRequestQuery(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class GetVirtualAccountOpenRequestQueryHandler : IRequestHandler<GetVirtualAccountOpenRequestQuery, VirtualAccountOpenRequestDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVirtualAccountOpenRequestQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VirtualAccountOpenRequestDto> Handle(GetVirtualAccountOpenRequestQuery request, CancellationToken cancellationToken)
        {
            return await _context.VirtualAccountOpenRequests.AsNoTracking()
                .Include(a => a.RequestedUser)
                .Include(a => a.DatabaseType)
                .Include(a => a.AccountType)
                .Include(a => a.Currency)
                .Include(a => a.BankReconciliationsToBePreparedByUser)
                .Include(a => a.BankReconciliationsToBeReviewedByUser)
                .Where(a => a.Guid == request.Guid)
                .ProjectTo<VirtualAccountOpenRequestDto>(_mapper.ConfigurationProvider)
                .SingleAsync(cancellationToken);
        }
    }
}