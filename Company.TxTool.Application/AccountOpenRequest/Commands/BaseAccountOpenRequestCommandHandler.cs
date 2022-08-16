using System;
using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Extensions;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.AccountOpenRequest.Commands
{
    public class BaseAccountOpenRequestCommandHandler
    {
        protected readonly IApplicationDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseAccountOpenRequestCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<PhysicalAccountOpenRequest> GetUpdatedPhysicalEntityForRequestor(Guid guid, PhysicalAccountOpenRequestRequestorSectionDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.PhysicalAccountOpenRequests
                .Include(x => x.SupportingDocumentation)
                .Where(a => a.Guid == guid)
                .SingleOrDefaultAsync(cancellationToken);
            ThrowIfNull(guid, entity);

            _mapper.Map(dto, entity);
            entity!.SupportingDocumentation.Sync(dto.SupportingDocumentation, e => e.SupportDocumentId, id => new AccountOpenRequestBSupportingDocumentation(id));

            return entity;
        }

        protected async Task<PhysicalAccountOpenRequest> GetPhysicalEntityForReviewer(Guid guid, CancellationToken cancellationToken)
        {
            var entity = await _context.PhysicalAccountOpenRequests
                               .Include(x => x.DepositLetters)
                               .Include(x => x.LettersToBanks)
                               .Where(a => a.Guid == guid)
                               .SingleOrDefaultAsync(cancellationToken);
            ThrowIfNull(guid, entity);

            return entity!;
        }

        protected async Task<PhysicalAccountOpenRequest> GetUpdatedPhysicalEntityForReviewer(Guid guid, PhysicalAccountOpenRequestReviewerSectionDto dto, CancellationToken cancellationToken)
        {
            var entity = await GetPhysicalEntityForReviewer(guid, cancellationToken);

            _mapper.Map(dto, entity);
            entity!.LettersToBanks.Sync(dto.LetterSentToBank, e => e.SupportDocumentId, id => new AccountOpenRequestBLetterToBank(id));
            entity!.DepositLetters.Sync(dto.DepositLetters, e => e.SupportDocumentId, id => new AccountOpenRequestBDepositLetter(id));

            return entity;
        }

        protected async Task<BaseAccountOpenRequest> GetEntity(Guid guid, CancellationToken cancellationToken)
        {
            var entity = await _context.AccountOpenRequests
                       .Where(a => a.Guid == guid)
                       .SingleOrDefaultAsync(cancellationToken);
            ThrowIfNull(guid, entity);

            return entity!;
        }

        private static void ThrowIfNull(Guid guid, BaseAccountOpenRequest? entity)
        {
            Guard.Against.Null(entity, nameof(guid), $"There is no account open request entry found for {guid}");
        }
    }
}
