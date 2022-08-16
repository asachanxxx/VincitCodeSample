using System;

namespace Company.TxTool.Application.Common.Interfaces
{
    public interface IStorageService
    {
        Task<byte[]> DownloadSupportDocument(Guid blobName, CancellationToken cancellationToken);

        Task<Uri> UploadSupportDocument(Guid blobName, byte[] data, string mimeType, CancellationToken cancellationToken);
    }
}
