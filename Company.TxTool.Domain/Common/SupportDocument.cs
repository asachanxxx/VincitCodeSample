using System;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;
using Cushwake.TreasuryTool.Domain.Picklist;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Common
{
    public class SupportDocument : BaseAuditableEntity, IBelongToTenant
    {
        public SupportDocument()
        {
            FileName = default!;
            MimeType = default!;
            Uri = default!;
            UploadedBy = default!;
            UploadedByUser = default!;
        }

        public Guid Guid
        {
            get; set;
        }

        public string FileName
        {
            get; set;
        }

        public string MimeType
        {
            get; set;
        }

        public int? DocumentTypeId
        {
            get; set;
        }

        public DocumentType? DocumentType
        {
            get; set;
        }

        public Uri Uri
        {
            get; set;
        }

        public int UploadedBy
        {
            get; set;
        }

        public User UploadedByUser
        {
            get; set;
        }

        public DateTime UploadedOn
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }
    }
}
