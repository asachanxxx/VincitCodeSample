using System;
using Company.TxTool.Application.Common.Mappings;

namespace Company.TxTool.Application.SupportDocument
{
    public class SupportDocumentDto : IMapFrom<Domain.Common.SupportDocument>
    {
        public SupportDocumentDto()
        {
            FileName = default!;
        }

        public int Id
        {
            get; set;
        }

        public Guid Guid
        {
            get; set;
        }

        public string FileName
        {
            get; set;
        }

        public int? DocumentTypeId
        {
            get; set;
        }
    }
}
