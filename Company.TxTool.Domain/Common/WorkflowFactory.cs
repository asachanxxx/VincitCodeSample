using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.Common
{
    public class WorkflowFactory : IWorkflowFactory
    {
        public IAccountOpenRequestWorkflow GetAccountOpenRequestWorkflow(BaseAccountOpenRequest request)
        {
            return new DefaultAccountOpenRequestWorkflow(request);
        }
    }
}
