using System;
using Cushwake.TreasuryTool.Domain.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> entity)
        {
            entity.ToTable("Notification", "app");

            entity.Property(e => e.Id).HasColumnName("NotificationID");

            entity.Property(e => e.Type)
                .HasConversion(
                    e => e.Value,
                    e => NotificationTypeEnum.FromValue(e));

            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.Property(e => e.Message).HasMaxLength(255);

            entity.Property(e => e.IsUnread);

            entity.Property(e => e.TargetEntityId);
            entity.Property(e => e.TargetEntityType).HasMaxLength(50);

            entity.HasOne(e => e.Owner)
               .WithMany()
               .HasForeignKey(e => e.OwnerId)
               .HasConstraintName("FK_Notification_OwnderID");

            entity.HasIndex(e => new { e.OwnerId, e.IsUnread }, "IX_Notification_OwnderID_IsUnread");
        }
    }
}
