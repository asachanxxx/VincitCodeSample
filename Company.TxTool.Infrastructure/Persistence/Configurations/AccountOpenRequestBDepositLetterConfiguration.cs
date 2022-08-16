using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountOpenRequestBDepositLetterConfiguration : IEntityTypeConfiguration<AccountOpenRequestBDepositLetter>
    {
        public void Configure(EntityTypeBuilder<AccountOpenRequestBDepositLetter> entity)
        {
            entity.HasKey(e => e.SupportDocumentId);

            entity.ToTable("AccountOpenRequest_b_DepositLetter", "app");

            entity.Property(e => e.SupportDocumentId).HasColumnName("SupportDocumentID");

            entity.HasOne(d => d.SupportDocument)
                .WithMany()
                .HasForeignKey(d => d.SupportDocumentId)
                .HasConstraintName("FK_AccountOpenRequest_b_DepositLetter_SupportDocumentID");
        }
    }
}
