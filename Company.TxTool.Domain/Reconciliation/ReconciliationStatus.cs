namespace Cushwake.TreasuryTool.Domain.Reconciliation;

public enum ReconciliationStatus : byte
{
    Pending = 1,
    InPreparation = 2,
    Submitted = 3,
    InReview = 4,
    Rejected = 5,
    Completed = 6
}
