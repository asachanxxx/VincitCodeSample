using System;

namespace Company.TxTool.Application.SupportDocument
{
    public class SupportDocumentDownloadDto
    {
        public SupportDocumentDownloadDto(string fileName, string mimeType, byte[] fileContent)
        {
            FileContent = fileContent;
            FileName = fileName;
            MimeType = mimeType;
        }

        public byte[] FileContent
        {
            get;
        }

        public string FileName
        {
            get;
        }

        public string MimeType
        {
            get;
        }
    }
}
