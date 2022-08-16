using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class ApplicationRoleBPermissionConfiguration : IEntityTypeConfiguration<ApplicationRoleBPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleBPermission> entity)
        {
            entity.HasKey(e => new { e.ApplicationRoleId, e.PermissionId });

            entity.ToTable("ApplicationRole_b_Permission", "usr");

            entity.Property(e => e.ApplicationRoleId).HasColumnName("ApplicationRoleID");

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

            entity.Property(e => e.IsActive);

            entity.Property(e => e.IsDefault);

            entity.HasOne(d => d.ApplicationRole)
                .WithMany(p => p.ApplicationRoleBPermissions)
                .HasForeignKey(d => d.ApplicationRoleId)
                .HasConstraintName("FK_ApplicationRole_b_Permission_ApplicationRole");

            entity.HasOne(d => d.Permission)
                .WithMany()
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK_ApplicationRole_b_Permission_Permission");
        }
    }
}
