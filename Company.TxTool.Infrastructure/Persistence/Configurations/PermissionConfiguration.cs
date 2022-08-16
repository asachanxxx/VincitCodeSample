using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.ToTable("Permission", "usr");

            entity.Property(e => e.Id).HasColumnName("PermissionID");

            entity.Property(e => e.PermissionCode).HasMaxLength(100);

            entity.Property(e => e.PermissionName).HasMaxLength(255);

            entity.Property(e => e.IsActive);

            entity.HasIndex(e => e.PermissionCode, "UIX_PermissionCode")
                .IsUnique();
        }
    }
}
