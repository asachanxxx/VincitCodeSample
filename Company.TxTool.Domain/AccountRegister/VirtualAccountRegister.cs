using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class VirtualAccountRegister : PvBaseAccountRegister
    {
        public VirtualAccountRegister()
        {
            PostingRulesInBMAPDebtorClientRef = default!;
            TransactionTypeCode = default!;
            PropertyNumber = default!;
            ExpenseCode = default!;
            ScheduleRef = default!;
            ChartCode = default!;
            VirtualAccountNumber = default!;
            Status = AccountRegisterStatusEnum.Draft;
        }

        public VirtualAccountRegister(int requestedBy, DateTime requestedOn) : this()
        {
            RequestedBy = requestedBy;
            RequestedOn = requestedOn;
        }

        public string? PostingRulesInBMAPDebtorClientRef
        {
            get; set;
        }

        public string? TransactionTypeCode
        {
            get; set;
        }

        public string? PropertyNumber
        {
            get; set;
        }

        public string? ExpenseCode
        {
            get; set;
        }

        public string? ScheduleRef
        {
            get; set;
        }

        public string? ChartCode
        {
            get; set;
        }

        public string? VirtualAccountNumber
        {
            get; set;
        }
    }
}