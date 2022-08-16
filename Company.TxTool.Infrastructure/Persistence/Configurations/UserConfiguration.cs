using Cushwake.TreasuryTool.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User", "usr");

            entity.Property(e => e.Id).HasColumnName("UserID");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.ApplicationRoleID);

            entity.Property(e => e.FirstName).HasMaxLength(255);

            entity.Property(e => e.LastName).HasMaxLength(255);

            entity.Property(e => e.IsActive);

            entity.Property(e => e.UserGraphId).HasColumnName("UserGraphID");

            entity.Property(e => e.WorkEmail).HasMaxLength(255);

            entity.HasOne(e => e.Role)
                .WithOne()
                .HasForeignKey<User>(d => d.ApplicationRoleID)
                .HasConstraintName("FK_User_ApplicationRoleID")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.ApplicationRoleID, "UIX_User_ApplicationRoleID")
                .IsUnique();
            entity.HasIndex(e => e.UserGraphId, "UIX_User_UserGraphID")
                .IsUnique();
            entity.HasIndex(e => e.WorkEmail, "UIX_User_WorkEmail")
                .IsUnique();
        }
    }
}
