namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class PhysicalAccountOpenRequest : PvBaseAccountOpenRequest
    {
        private PhysicalAccountOpenRequest()
        {
            PayingInBooksToGoTo = default!;
            SortCode = default!;
            AccountNumber = default!;
            SupportingDocumentation = new List<AccountOpenRequestBSupportingDocumentation>();
            LettersToBanks = default!;
            DepositLetters = default!;
            Status = AccountOpenRequestStatusEnum.Draft;
            Guid = Guid.NewGuid();
        }

        public PhysicalAccountOpenRequest(int requestedBy, DateTime requestedOn) : this()
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

        public virtual ICollection<AccountOpenRequestBSupportingDocumentation> SupportingDocumentation
        {
            get; set;
        }

        public void SetupRequestedDate(DateTime requestedOn)
        {
            RequestedOn = requestedOn;
        }
    }
}
