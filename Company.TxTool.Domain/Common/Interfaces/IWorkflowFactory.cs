using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.Common.Interfaces
{
    public interface IWorkflowFactory
    {
        IAccountOpenRequestWorkflow GetAccountOpenRequestWorkflow(BaseAccountOpenRequest request);
    }
}
