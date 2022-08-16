using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public enum AccountRegisterDocumentTypeEnum : byte
    {
        SupportingDocumentation = 1,
        DepositLetters = 2,
        LettersToBanks = 3
    }
}