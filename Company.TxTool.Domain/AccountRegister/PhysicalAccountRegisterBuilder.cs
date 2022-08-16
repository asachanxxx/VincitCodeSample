using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class PhysicalAccountRegisterBuilder : IAccountRegisterBuilder
    {
        private readonly PhysicalAccountOpenRequest _request;

        public PhysicalAccountRegisterBuilder(PhysicalAccountOpenRequest request)
        {
            _request = request;
        }

        public AccountRegister Build()
        {
            // Create a new account register and attach a reconciliation schedule to it
            throw new NotImplementedException();
        }
    }
}
