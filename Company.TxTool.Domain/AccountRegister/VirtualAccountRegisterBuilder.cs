using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;

namespace Cushwake.TreasuryTool.Domain.AccountRegister
{
    public class VirtualAccountRegisterBuilder : IAccountRegisterBuilder
    {
        private readonly VirtualAccountOpenRequest _request;

        public VirtualAccountRegisterBuilder(VirtualAccountOpenRequest request)
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
