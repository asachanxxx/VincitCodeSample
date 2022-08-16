using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class AccountRegisterBDocumentation : IBelongToTenant
    {
        private AccountRegisterBDocumentation()
        {
            Document = default!;
            // AccountRegister = default!;
        }

        public AccountRegisterBDocumentation(int documentId) : this()
        {
            this.DocumentId = documentId;
        }

        public int DocumentId
        {
            get; set;
        }

        public virtual SupportDocument Document
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

        public AccountRegisterDocumentTypeEnum DocumentType
        {
            get; set;
        }

        //public virtual AccountRegister AccountRegister
        //{
        //    get; set;
        //}

        public int AccountRegisterId
        {
            get; set;
        }
    }
}