using System;
using Ardalis.SmartEnum;

namespace Cushwake.TreasuryTool.Domain.Common.Enums
{
    public class ApplicationRoleEnum : SmartEnum<ApplicationRoleEnum>
    {
        protected ApplicationRoleEnum(string name, int value) : base(name, value)
        {
        }

        public static readonly ApplicationRoleEnum Administrator = new(nameof(Administrator), 1);
        public static readonly ApplicationRoleEnum BankAdmin = new(nameof(BankAdmin), 1);
        public static readonly ApplicationRoleEnum GeneralAccounting = new(nameof(GeneralAccounting), 1);
    }
}
