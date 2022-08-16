using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> entity)
        {
            entity.ToTable("ApplicationRole", "usr");

            entity.Property(e => e.Id).HasColumnName("ApplicationRoleID");

            entity.Property(e => e.CopiedFromApplicationRoleID);

            entity.Property(e => e.ApplicationRoleCode).HasMaxLength(100)
                .HasConversion(
                    p => p.Name,
                    p => ApplicationRoleEnum.FromName(p, true));

            entity.Property(e => e.ApplicationRoleName).HasMaxLength(255);

            entity.Property(e => e.IsActive);

            entity.Property(e => e.IsStandardRole);

            entity.HasOne(d => d.CopiedFromApplicationRole)
               .WithMany()
               .HasForeignKey(e => e.CopiedFromApplicationRoleID)
               .HasConstraintName("FK_ApplicationRole_CopiedFromApplicationRoleID");
        }
    }
}
