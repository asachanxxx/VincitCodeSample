using System;
using Cushwake.TreasuryTool.Domain.Audit;
using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class UserAuditConfiguration : IEntityTypeConfiguration<UserAudit>
    {
        public void Configure(EntityTypeBuilder<UserAudit> entity)
        {
            entity.ToTable("UserAudit", "audit");

            entity.Property(e => e.Id).HasColumnName("UserAuditID");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.Property(e => e.Action).HasMaxLength(50);

            entity.Property(e => e.ActionedByEmail).HasMaxLength(255);

            entity.Property(e => e.ActionedById).HasColumnName("ActionedByID");

            entity.Property(e => e.ActionedOn);

            entity.Property(e => e.Summary).HasMaxLength(255);

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserAudit_UserID")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(d => d.ActionedById)
                .HasConstraintName("FK_UserAudit_ActionedByID")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.UserId, "IX_UserAudit_UserID");
        }
    }
}