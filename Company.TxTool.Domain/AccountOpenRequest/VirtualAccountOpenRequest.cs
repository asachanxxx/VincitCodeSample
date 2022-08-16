namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class VirtualAccountOpenRequest : PvBaseAccountOpenRequest
    {
        public VirtualAccountOpenRequest()
        {
            PostingRulesInBMAPDebtorClientRef = default!;
            TransactionTypeCode = default!;
            PropertyNumber = default!;
            ExpenseCode = default!;
            ScheduleRef = default!;
            ChartCode = default!;
            VirtualAccountNumber = default!;
            Status = AccountOpenRequestStatusEnum.Draft;
        }

        public VirtualAccountOpenRequest(int requestedBy, DateTime requestedOn) : this()
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