using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class ReconciliationScheduleConfiguration : IEntityTypeConfiguration<ReconciliationSchedule>
    {
        public void Configure(EntityTypeBuilder<ReconciliationSchedule> entity)
        {
            entity.ToTable("ReconciliationSchedule", "app");

            entity.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_ReconciliationSchedule_TenantID");

            entity.HasOne(e => e.ReviewedBy)
              .WithMany()
              .HasForeignKey("ReviewedById")
              .HasConstraintName("FK_ReconciliationSchedule_ReviewedById");

            entity.Property(e => e.Frequency).HasMaxLength(100)
                .HasConversion(
                    e => e.Name,
                    e => ReconciliationFrequencyEnum.FromName(e, true));

            entity.Property(e => e.TriggerGapBeforeEvent)
                .HasConversion(
                    e => e.Ticks,
                    e => TimeSpan.FromTicks(e));

            entity.Property(e => e.DeadlineAfterEvent)
                .HasConversion(
                    e => e.Ticks,
                    e => TimeSpan.FromTicks(e));
        }
    }
}
