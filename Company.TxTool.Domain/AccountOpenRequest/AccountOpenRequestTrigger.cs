namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public enum AccountOpenRequestTrigger : byte
    {
        Create = 1,
        Submitting = 2,
        StartReviewing = 3,
        Rejecting = 4,
        Completing = 5
    }
}
