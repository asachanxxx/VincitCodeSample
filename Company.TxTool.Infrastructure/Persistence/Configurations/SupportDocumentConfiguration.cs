using System;
using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class SupportDocumentConfiguration : IEntityTypeConfiguration<SupportDocument>
    {
        public void Configure(EntityTypeBuilder<SupportDocument> entity)
        {
            entity.ToTable("SupportDocument", "app");

            entity.Property(e => e.Id).HasColumnName("SupportDocumentID");

            entity.Property(e => e.Guid).HasDefaultValueSql("(NewId())");

            entity.Property(e => e.FileName).HasMaxLength(255);

            entity.Property(e => e.MimeType).HasMaxLength(100);

            entity.Property(e => e.Uri).HasMaxLength(1000)
                .HasConversion(
                    v => v.ToString(),
                    v => new Uri(v));

            entity.Property(e => e.UploadedOn).HasPrecision(2);

            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            entity.Property(e => e.IsActive);

            entity.HasOne(e => e.DocumentType)
                .WithMany()
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_SupportDocument_DocumentTypeID");

            entity.HasOne(e => e.UploadedByUser)
                .WithMany()
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK_SupportDocument_UploadedBy");

            entity.HasIndex(e => e.Guid, "UIX_SupportDocument_Guid")
                .IsUnique();
        }
    }
}
