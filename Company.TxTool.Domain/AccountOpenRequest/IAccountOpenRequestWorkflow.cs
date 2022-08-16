namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public interface IAccountOpenRequestWorkflow
    {
        void Fire(AccountOpenRequestTrigger trigger);
    }
}