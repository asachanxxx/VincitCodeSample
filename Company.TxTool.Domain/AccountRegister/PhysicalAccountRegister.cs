using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class PhysicalAccountRegister : PvBaseAccountRegister
    {
        private PhysicalAccountRegister()
        {
            PayingInBooksToGoTo = default!;
            SortCode = default!;
            AccountNumber = default!;
            Status = AccountRegisterStatusEnum.Draft;
            Guid = Guid.NewGuid();
        }

        public PhysicalAccountRegister(int requestedBy, DateTime requestedOn) : this()
        {
            RequestedBy = requestedBy;
            RequestedOn = requestedOn;
        }

        public string? PayingInBooksToGoTo
        {
            get; set;
        }

        public string? SortCode
        {
            get; set;
        }

        public string? AccountNumber
        {
            get; set;
        }

        public void SetupRequestedDate(DateTime requestedOn)
        {
            RequestedOn = requestedOn;
        }
    }
}