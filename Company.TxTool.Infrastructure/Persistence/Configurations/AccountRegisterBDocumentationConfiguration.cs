using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountRegisterBDocumentationConfiguration : IEntityTypeConfiguration<AccountRegisterBDocumentation>
    {
        public void Configure(EntityTypeBuilder<AccountRegisterBDocumentation> entity)
        {
            entity.HasKey(e => new { e.AccountRegisterId, e.DocumentId });

            entity.ToTable("AccountRegister_b_Document", "app");

            entity.Property(e => e.DocumentId).HasColumnName("SupportDocumentID");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_AccountRegister_b_Document_SupportDocumentID");
        }
    }
}