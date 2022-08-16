using System;
using Ardalis.SmartEnum;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.Picklist
{
    public class PicklistType : IBelongToTenant
    {
        private PicklistType()
        {
            Code = default!;
            Value = default!;
        }

        public PicklistTypeEnum Value
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

    public abstract class PicklistTypeEnum : SmartEnum<PicklistTypeEnum>
    {
        private PicklistTypeEnum(string name, byte value) : base(name, value)
        {
        }

        public static readonly PicklistTypeEnum DatabaseType = new DatabaseTypeEnum();
        public static readonly PicklistTypeEnum AccountType = new AccountTypeEnum();
        public static readonly PicklistTypeEnum DocumentType = new DocumentTypeEnum();
        public static readonly PicklistTypeEnum PhysicalAccountType = new PhysicalAccountTypeEnum();
        public static readonly PicklistTypeEnum Currency = new CurrencyEnum();
        public static readonly PicklistTypeEnum Bank = new BankEnum();

        public abstract BasePicklistItem GetPicklistItem(string name, bool isActive);

        private sealed class DatabaseTypeEnum : PicklistTypeEnum
        {
            public DatabaseTypeEnum() : base(nameof(DatabaseType), 1)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new DatabaseType(name, isActive);
            }
        }

        private sealed class AccountTypeEnum : PicklistTypeEnum
        {
            public AccountTypeEnum() : base(nameof(AccountType), 2)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new AccountType(name, isActive);
            }
        }

        private sealed class DocumentTypeEnum : PicklistTypeEnum
        {
            public DocumentTypeEnum() : base(nameof(DocumentType), 3)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new DocumentType(name, isActive);
            }
        }

        private sealed class PhysicalAccountTypeEnum : PicklistTypeEnum
        {
            public PhysicalAccountTypeEnum() : base(nameof(PhysicalAccountType), 4)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new PhysicalAccountType(name, isActive);
            }
        }

        private sealed class CurrencyEnum : PicklistTypeEnum
        {
            public CurrencyEnum() : base(nameof(Currency), 5)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new Currency(name, isActive);
            }
        }

        private sealed class BankEnum : PicklistTypeEnum
        {
            public BankEnum() : base(nameof(Bank), 6)
            {
            }

            public override BasePicklistItem GetPicklistItem(string name, bool isActive)
            {
                return new Currency(name, isActive);
            }
        }
    }
}