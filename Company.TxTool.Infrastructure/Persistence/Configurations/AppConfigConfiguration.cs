using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> entity)
        {
            entity.ToTable("AppConfig", "app");

            entity.Property(e => e.AppConfigId).HasColumnName("AppConfigID");

            entity.Property(e => e.AppConfigCode).HasMaxLength(20);

            entity.Property(e => e.AppConfigName).HasMaxLength(255);

            entity.Property(e => e.AppConfigText).HasMaxLength(4000);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasIndex(e => e.AppConfigName, "IX_AppConfigName")
                .IsUnique();
        }
    }
}
