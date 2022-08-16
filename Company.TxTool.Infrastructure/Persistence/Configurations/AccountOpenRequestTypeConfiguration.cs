using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountOpenRequestTypeConfiguration : IEntityTypeConfiguration<AccountOpenRequestType>
    {
        public void Configure(EntityTypeBuilder<AccountOpenRequestType> entity)
        {
            entity.ToTable("AccountOpenRequestType", "lkp");

            entity.Property<int>("TenantID");
            entity.HasKey("TenantID", nameof(AccountOpenRequestType.Value));

            entity.Property(e => e.Value)
                .HasConversion(
                    p => p.Value,
                    p => AccountOpenRequestTypeEnum.FromValue(p));

            entity.Property(e => e.Code).HasMaxLength(50);

            entity.Property(e => e.MemberOrderKey);

            entity.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_AccountOpenRequestType_TenantID");
        }
    }
}
