using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Commands
{
    public class BaseVirtualAccountOpenRequestCommandHandler
    {
        protected readonly IApplicationDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseVirtualAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<VirtualAccountOpenRequest> GetUpdatedEntityForReviewer(Guid guid, VirtualAccountOpenRequestRequestorSectionDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.VirtualAccountOpenRequests
                .Where(a => a.Guid == guid)
                .SingleOrDefaultAsync(cancellationToken);
            ThrowIfNull(guid, entity);

            _mapper.Map(dto, entity);

            return entity!;
        }

        private static void ThrowIfNull(Guid guid, VirtualAccountOpenRequest? entity)
        {
            Guard.Against.Null(entity, nameof(guid), $"There is no physical account open request entry found for {guid}");
        }
    }
}