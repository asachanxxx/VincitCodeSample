using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public enum AccountRegisterStatusEnum : byte
    {
        Draft = 1,
        Submitted = 2,
        InReview = 3,
        Rejected = 4,
        Completed = 5
    }
}