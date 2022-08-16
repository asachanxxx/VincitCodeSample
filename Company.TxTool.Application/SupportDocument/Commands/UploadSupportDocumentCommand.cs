using System;
using Ardalis.GuardClauses;
using AutoMapper;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.SupportDocument;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Company.TxTool.Application.SupportDocument.Commands
{
    public class UploadSupportDocumentCommand : IRequest<SupportDocumentDto>
    {
        public UploadSupportDocumentCommand(IFormFileCollection files, IFormCollection form)
        {
            var file = files["Document"];
            Guard.Against.Null(file, nameof(files), "Form files should contain 'Document'.");

            using (var stream = file.OpenReadStream())
            {
                using var binaryReader = new BinaryReader(stream);
                FileContent = binaryReader.ReadBytes((int)stream.Length);
            }

            FileName = file.FileName;
            MimeType = file.ContentType;
            if (int.TryParse(form["DocumentTypeId"], out var documentTypeId))
            {
                DocumentTypeId = documentTypeId;
            }
        }

        public string FileName
        {
            get;
        }

        public string MimeType
        {
            get;
        }

        public byte[] FileContent
        {
            get;
        }

        public int? DocumentTypeId
        {
            get;
        }
    }

    public class UploadSupportDocumentCommandHandler : IRequestHandler<UploadSupportDocumentCommand, SupportDocumentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTimeService;
        private readonly IMapper _mapper;

        public UploadSupportDocumentCommandHandler(IApplicationDbContext context, IStorageService storageService, ICurrentUserService currentUserService, IDateTime dateTimeService, IMapper mapper)
        {
            _context = context;
            _storageService = storageService;
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        public async Task<SupportDocumentDto> Handle(UploadSupportDocumentCommand dto, CancellationToken cancellationToken)
        {
            var blobName = Guid.NewGuid();
            var uri = await _storageService.UploadSupportDocument(blobName, dto.FileContent, dto.MimeType, cancellationToken);

            var document = new Domain.Common.SupportDocument
            {
                Guid = blobName,
                FileName = dto.FileName,
                MimeType = dto.MimeType,
                DocumentTypeId = dto.DocumentTypeId,
                Uri = uri,
                UploadedBy = _currentUserService.User.UserID,
                UploadedOn = _dateTimeService.UtcNow,
                IsActive = true
            };

            await _context.SupportDocuments.AddAsync(document, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Domain.Common.SupportDocument, SupportDocumentDto>(document);
        }
    }
}
