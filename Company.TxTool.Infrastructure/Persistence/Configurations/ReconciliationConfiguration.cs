using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Reconciliation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class ReconciliationConfiguration : IEntityTypeConfiguration<Reconciliation>
    {
        public void Configure(EntityTypeBuilder<Reconciliation> entity)
        {
            entity.ToTable("Reconciliation", "app");

            entity.Property(e => e.Type)
                .HasConversion(
                    p => p.Value,
                    p => ReconciliationTypeEnum.FromValue(p));

            entity.Property(e => e.OriginFrequency).HasMaxLength(100)
                .HasConversion(
                    e => e.Name,
                    e => ReconciliationFrequencyEnum.FromName(e, true));
        }
    }
}