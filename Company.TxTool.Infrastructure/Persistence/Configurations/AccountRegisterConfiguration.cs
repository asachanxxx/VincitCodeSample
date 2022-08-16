using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountRegisterConfiguration : IEntityTypeConfiguration<AccountRegister>
    {
        public void Configure(EntityTypeBuilder<AccountRegister> entity)
        {
            entity.ToTable("AccountRegister", "app");

            entity.Property(e => e.Id).HasColumnName("AccountRegisterID");
            entity.Property(e => e.Guid).HasDefaultValueSql("(NewId())");
            entity.Property(e => e.ClientName).HasMaxLength(255);

            entity.Property(e => e.RequestedOn).HasPrecision(2);
            entity.Property(e => e.RequestedBy);
            entity.Property(e => e.ReviewedOn).HasPrecision(2);
            entity.Property(e => e.ReviewedBy);

            entity.Property(e => e.Status);
            entity.Property<int>("TenantID");

            entity.HasDiscriminator(e => e.Type)
              .HasValue<PhysicalAccountRegister>(AccountOpenRequestTypeEnum.Physical)
              .HasValue<VirtualAccountRegister>(AccountOpenRequestTypeEnum.Virtual);

            entity.HasOne<AccountOpenRequestType>()
               .WithMany()
               .HasForeignKey("TenantID", nameof(AccountRegister.Type))
               .HasConstraintName("FK_AccountRegister_TenantID_Type");

            entity.HasOne(e => e.RequestedUser)
               .WithMany()
               .HasForeignKey(d => d.RequestedBy)
               .HasConstraintName("FK_AccountRegister_RequestedBy");

            entity.HasOne(e => e.DatabaseType)
               .WithMany()
               .HasForeignKey(e => e.DatabaseTypeID)
               .HasConstraintName("FK_AccountRegister_DatabaseTypeID");

            entity.HasOne(e => e.ReviewedUser)
                .WithMany()
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("FK_AccountRegister_ReviewedBy");

            entity.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_AccountRegister_TenantID");

            entity.HasOne(e => e.ReconciliationSchedule)
              .WithOne(e => e.AccountRegister)
              .HasForeignKey<AccountRegister>(d => d.ReconciliationScheduleId)
              .HasConstraintName("FK_AccountRegister_ReconciliationScheduleId");

            entity.HasIndex(e => e.Type, "IX_AccountRegister_Type");
            entity.HasIndex(e => e.Status, "IX_AccountRegister_Status");
            entity.HasIndex(e => e.Guid, "UIX_AccountRegister_Guid")
                .IsUnique();
        }
    }
}