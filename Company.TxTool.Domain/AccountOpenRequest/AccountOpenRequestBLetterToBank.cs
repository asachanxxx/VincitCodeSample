using System;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class AccountOpenRequestBLetterToBank : IBelongToTenant
    {
        private AccountOpenRequestBLetterToBank()
        {
            SupportDocument = default!;
        }

        public AccountOpenRequestBLetterToBank(int supportDocumentId) : this()
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
