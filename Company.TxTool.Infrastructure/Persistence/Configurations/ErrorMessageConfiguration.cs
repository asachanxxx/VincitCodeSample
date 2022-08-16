using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class ErrorMessageConfiguration : IEntityTypeConfiguration<ErrorMessage>
    {
        public void Configure(EntityTypeBuilder<ErrorMessage> entity)
        {
            entity.ToTable("ErrorMessage", "app");

            entity.HasIndex(e => e.ErrorMessageName, "IX_ErrorMessageName")
                .IsUnique();

            entity.HasIndex(e => e.ModifiedbyId, "IX_ModifiedByID");

            entity.Property(e => e.ErrorMessageId).HasColumnName("ErrorMessageID");

            entity.Property(e => e.ErrorMessageCode).HasMaxLength(20);

            entity.Property(e => e.ErrorMessageName).HasMaxLength(255);

            entity.Property(e => e.ErrorMessageText).HasMaxLength(4000);
        }
    }
}
