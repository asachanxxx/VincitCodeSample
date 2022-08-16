using Cushwake.TreasuryTool.Domain.Common;
using Cushwake.TreasuryTool.Domain.Picklist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class PicklistItemConfiguration : IEntityTypeConfiguration<BasePicklistItem>
    {
        public void Configure(EntityTypeBuilder<BasePicklistItem> entity)
        {
            entity.ToTable("PicklistItem", "lkp");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.MemberOrderKey);
            entity.Property(e => e.IsActive);
            entity.Property<int>("TenantID");

            entity.HasDiscriminator(e => e.Type)
                .HasValue<DatabaseType>(PicklistTypeEnum.DatabaseType)
                .HasValue<AccountType>(PicklistTypeEnum.AccountType)
                .HasValue<PhysicalAccountType>(PicklistTypeEnum.PhysicalAccountType)
                .HasValue<DocumentType>(PicklistTypeEnum.DocumentType)
                .HasValue<Currency>(PicklistTypeEnum.Currency)
                .HasValue<Bank>(PicklistTypeEnum.Bank);

            entity.HasOne<PicklistType>()
                .WithMany()
                .HasForeignKey("TenantID", nameof(BasePicklistItem.Type))
                .HasConstraintName("FK_PicklistItem_TenantID_Type");

            entity.HasOne<Tenant>()
                .WithMany()
                .HasForeignKey("TenantID")
                .HasConstraintName("FK_PicklistItem_TenantID");

            entity.HasIndex("TenantID", nameof(BasePicklistItem.Type), nameof(BasePicklistItem.Code))
                .HasDatabaseName("UIX_PicklistItem_TenantID_Type_Code")
                .IsUnique();

            entity.HasIndex("TenantID", nameof(BasePicklistItem.Type), nameof(BasePicklistItem.Name))
                .HasDatabaseName("UIX_PicklistItem_TenantID_Type_Name")
                .IsUnique();

            entity.HasIndex(e => e.Type, "IX_PicklistItem_Type");
        }
    }
}