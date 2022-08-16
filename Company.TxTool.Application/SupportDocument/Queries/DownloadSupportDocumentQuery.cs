using System;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.TxTool.Application.SupportDocument.Queries
{
    public class DownloadSupportDocumentQuery : IRequest<SupportDocumentDownloadDto>
    {
        public DownloadSupportDocumentQuery(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid
        {
            get;
        }
    }

    public class DownloadSupportDocumentQueryHandler : IRequestHandler<DownloadSupportDocumentQuery, SupportDocumentDownloadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorageService _storageService;

        public DownloadSupportDocumentQueryHandler(IApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<SupportDocumentDownloadDto> Handle(DownloadSupportDocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await _context.SupportDocuments.AsNoTracking()
                .Where(d => d.Guid == request.Guid && d.IsActive)
                .SingleOrDefaultAsync(cancellationToken);
            if (document == null)
            {
                throw new NotFoundException("Support Document", request.Guid.ToString());
            }

            var fileContent = await _storageService.DownloadSupportDocument(request.Guid, cancellationToken);
            return new SupportDocumentDownloadDto(document.FileName, document.MimeType, fileContent);
        }
    }
}
