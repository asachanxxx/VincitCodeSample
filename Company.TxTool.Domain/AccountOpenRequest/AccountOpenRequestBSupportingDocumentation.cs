using System;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class AccountOpenRequestBSupportingDocumentation : IBelongToTenant
    {
        private AccountOpenRequestBSupportingDocumentation()
        {
            SupportDocument = default!;
        }

        public AccountOpenRequestBSupportingDocumentation(int supportDocumentId) : this()
        {
            SupportDocumentId = supportDocumentId;
        }

        public int SupportDocumentId
        {
            get; set;
        }

        public virtual SupportDocument SupportDocument
        {
            get; set;
        }

        public DateTime? Created
        {
            get; set;
        }

        public int? CreatedById
        {
            get; set;
        }

        public DateTime? Modified
        {
            get; set;
        }

        public int? ModifiedById
        {
            get; set;
        }
    }
}
