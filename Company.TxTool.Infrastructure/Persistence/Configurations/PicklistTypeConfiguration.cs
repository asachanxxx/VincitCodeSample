using System;
using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Picklist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class PicklistTypeConfiguration : IEntityTypeConfiguration<PicklistType>
    {
        public void Configure(EntityTypeBuilder<PicklistType> entity)
        {
            entity.ToTable("PicklistType", "lkp");

            entity.Property<int>("TenantID");
            entity.HasKey("TenantID", nameof(PicklistType.Value));

            entity.Property(e => e.Value)
                .HasConversion(
                    p => p.Value,
                    p => PicklistTypeEnum.FromValue(p));

            entity.Property(e => e.Code).HasMaxLength(50);

            entity.Property(e => e.MemberOrderKey);

            entity.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_PicklistType_TenantID");
        }
    }
}
