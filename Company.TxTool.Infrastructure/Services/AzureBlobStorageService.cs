using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;

namespace Cushwake.TreasuryTool.Infrastructure.Services
{
    public class AzureBlobStorageService : IStorageService
    {
        private readonly IEnvironmentSettings _settings;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureBlobStorageService(IEnvironmentSettings settings, ICurrentUserService currentUserService)
        {
            _settings = settings;
            _containerName = _settings.BlobStorageContainerPrefix + currentUserService.User.TenantCode.ToLower();
            _blobServiceClient = new BlobServiceClient(settings.BlobStorageConnectionString);
        }

        public async Task<byte[]> DownloadSupportDocument(Guid blobName, CancellationToken cancellationToken)
        {
            var blob = GetBlob(blobName);
            if (!await blob.ExistsAsync(cancellationToken))
            {
                throw new NotFoundException("Support Document", blobName.ToString());
            }

            using var ms = new MemoryStream();
            await blob.DownloadToAsync(ms);
            return ms.ToArray();
        }

        public async Task<Uri> UploadSupportDocument(Guid blobName, byte[] data, string mimeType, CancellationToken cancellationToken)
        {
            var blob = GetBlob(blobName);

            using var ms = new MemoryStream(data);
            await blob.UploadAsync(ms, new BlobHttpHeaders { ContentType = mimeType });
            return blob.Uri;
        }

        private BlobClient GetBlob(Guid blobName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(_containerName);
            return container.GetBlobClient($"{_settings.BlobStorageSupportDocumentsFolder}/{blobName}");
        }
    }
}
