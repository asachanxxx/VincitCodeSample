using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountOpenRequestBSupportingDocumentationConfiguration : IEntityTypeConfiguration<AccountOpenRequestBSupportingDocumentation>
    {
        public void Configure(EntityTypeBuilder<AccountOpenRequestBSupportingDocumentation> entity)
        {
            entity.ToTable("AccountOpenRequest_b_SupportingDocumentation", "app");

            entity.HasKey(e => e.SupportDocumentId);

            entity.Property(e => e.SupportDocumentId).HasColumnName("SupportDocumentID");

            entity.HasOne(d => d.SupportDocument)
                .WithMany()
                .HasForeignKey(d => d.SupportDocumentId)
                .HasConstraintName("FK_AccountOpenRequest_b_SupportingDocumentation_SupportDocumentID");
        }
    }
}
