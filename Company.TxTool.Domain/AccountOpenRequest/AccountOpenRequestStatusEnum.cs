namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest;

public enum AccountOpenRequestStatusEnum : byte
{
    Draft = 1,
    Submitted = 2,
    InReview = 3,
    Rejected = 4,
    Completed = 5
}
