using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Queries.GetPhysicalAccountOpenRequest
{
    [AuthorizeForGeneralAccounting]
    [AuthorizeForBankAdmin]
    public record GetPhysicalAccountOpenRequestQuery : IRequest<PhysicalAccountOpenRequestDto>
    {
        public GetPhysicalAccountOpenRequestQuery(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class GetPhysicalAccountOpenRequestQueryHandler : IRequestHandler<GetPhysicalAccountOpenRequestQuery, PhysicalAccountOpenRequestDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPhysicalAccountOpenRequestQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PhysicalAccountOpenRequestDto> Handle(GetPhysicalAccountOpenRequestQuery request, CancellationToken cancellationToken)
        {
            var itemsx = await _context.PhysicalAccountOpenRequests.AsNoTracking()
                .Include(a => a.RequestedUser)
                .Include(a => a.DatabaseType)
                .Include(a => a.AccountType)
                .Include(a => a.Currency)
                .Include(a => a.BankReconciliationsToBePreparedByUser)
                .Include(a => a.BankReconciliationsToBeReviewedByUser)
                .Include(a => a.Bank)
                .Include(a => a.SupportingDocumentation).ThenInclude(d => d.SupportDocument)
                .Include(a => a.DepositLetters).ThenInclude(d => d.SupportDocument)
                .Include(a => a.LettersToBanks).ThenInclude(d => d.SupportDocument)
                .Where(a => a.Guid == request.Guid)
                .ProjectTo<PhysicalAccountOpenRequestDto>(_mapper.ConfigurationProvider)
                .SingleAsync(cancellationToken);
            return itemsx;
        }
    }
}