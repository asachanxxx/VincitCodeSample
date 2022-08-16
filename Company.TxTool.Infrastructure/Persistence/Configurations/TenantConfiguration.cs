using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> entity)
        {
            entity.ToTable("Tenant", "app");

            entity.Property(e => e.Id).HasColumnName("TenantID").ValueGeneratedNever();

            entity.Property(e => e.Code).HasMaxLength(10)
                .HasConversion(
                    p => p.Name,
                    p => TenantEnum.FromName(p, true));

            entity.Property(e => e.AdminEmail).HasMaxLength(100);

            entity.Property(e => e.CultureCode).HasMaxLength(10).HasDefaultValue("en-GB");

            entity.Property(e => e.TimeZoneName).HasMaxLength(100).HasDefaultValue("Sri Lanka Standard Time");

            entity.Property(e => e.IsActive);

            entity.HasIndex(e => e.Code, "UIX_Code")
                .IsUnique();

            entity.HasIndex(e => e.AdminEmail, "UIX_AdminEmail")
                .IsUnique();
        }
    }
}
