using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountOpenRequestConfiguration : IEntityTypeConfiguration<BaseAccountOpenRequest>
    {
        public void Configure(EntityTypeBuilder<BaseAccountOpenRequest> entity)
        {
            entity.ToTable("AccountOpenRequest", "app");

            entity.Property(e => e.Id).HasColumnName("AccountOpenRequestID");
            entity.Property(e => e.Guid).HasDefaultValueSql("(NewId())");
            entity.Property(e => e.ClientName).HasMaxLength(255);

            entity.Property(e => e.RequestedOn).HasPrecision(2);
            entity.Property(e => e.RequestedBy);
            entity.Property(e => e.ReviewedOn).HasPrecision(2);
            entity.Property(e => e.ReviewedBy);

            entity.Property(e => e.Status);
            entity.Property<int>("TenantID");

            entity.HasDiscriminator(e => e.Type)
                .HasValue<PhysicalAccountOpenRequest>(AccountOpenRequestTypeEnum.Physical)
                .HasValue<VirtualAccountOpenRequest>(AccountOpenRequestTypeEnum.Virtual);

            entity.HasOne<AccountOpenRequestType>()
                .WithMany()
                .HasForeignKey("TenantID", nameof(BaseAccountOpenRequest.Type))
                .HasConstraintName("FK_AccountOpenRequest_TenantID_Type");

            entity.HasOne(e => e.RequestedUser)
                .WithMany()
                .HasForeignKey(d => d.RequestedBy)
                .HasConstraintName("FK_AccountOpenRequest_RequestedBy");

            entity.HasOne(e => e.DatabaseType)
                .WithMany()
                .HasForeignKey(e => e.DatabaseTypeID)
                .HasConstraintName("FK_AccountOpenRequest_DatabaseTypeID");

            entity.HasOne(e => e.ReviewedUser)
                .WithMany()
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("FK_AccountOpenRequest_ReviewedBy");

            entity.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_AccountOpenRequest_TenantID");

            entity.HasIndex(e => e.Type, "IX_AccountOpenRequest_Type");
            entity.HasIndex(e => e.Status, "IX_AccountOpenRequest_Status");
            entity.HasIndex(e => e.Guid, "UIX_AccountOpenRequest_Guid")
                .IsUnique();
        }
    }
}
