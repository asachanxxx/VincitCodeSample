using Ardalis.SmartEnum;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.AccountOpenRequest
{
    public class AccountOpenRequestType : IBelongToTenant
    {
        public AccountOpenRequestType()
        {
            Value = default!;
            Code = default!;
        }

        public AccountOpenRequestTypeEnum Value
        {
            get; private set;
        }

        public string Code
        {
            get; private set;
        }

        public int? MemberOrderKey
        {
            get; private set;
        }
    }

    public abstract class AccountOpenRequestTypeEnum : SmartEnum<AccountOpenRequestTypeEnum>
    {
        private AccountOpenRequestTypeEnum(string name, byte value) : base(name, value)
        {
        }

        public abstract IAccountRegisterBuilder GetAccountRegisterBuilder(BaseAccountOpenRequest request);

        private sealed class PhysicalAccountOpenRequestType : AccountOpenRequestTypeEnum
        {
            public PhysicalAccountOpenRequestType() : base("Physical", 1)
            {
            }

            public override IAccountRegisterBuilder GetAccountRegisterBuilder(BaseAccountOpenRequest request) => new PhysicalAccountRegisterBuilder((request as PhysicalAccountOpenRequest)!);
        }

        private sealed class VirtualAccountOpenRequestType : AccountOpenRequestTypeEnum
        {
            public VirtualAccountOpenRequestType() : base("Virtual", 2)
            {
            }

            public override IAccountRegisterBuilder GetAccountRegisterBuilder(BaseAccountOpenRequest request) => new VirtualAccountRegisterBuilder((request as VirtualAccountOpenRequest)!);
        }

        public static readonly AccountOpenRequestTypeEnum Physical = new PhysicalAccountOpenRequestType();
        public static readonly AccountOpenRequestTypeEnum Virtual = new VirtualAccountOpenRequestType();
    }
}
