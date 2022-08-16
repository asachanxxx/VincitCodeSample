using System;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class AccountOpenRequestBDepositLetter : IBelongToTenant
    {
        private AccountOpenRequestBDepositLetter()
        {
            SupportDocument = default!;
        }

        public AccountOpenRequestBDepositLetter(int supportDocumentId) : this()
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
