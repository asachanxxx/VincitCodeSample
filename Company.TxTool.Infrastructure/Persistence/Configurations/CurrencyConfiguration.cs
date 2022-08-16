using System;
using Cushwake.TreasuryTool.Domain.Picklist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.Property(e => e.Sign).HasMaxLength(3).HasColumnName("CurrencySign");
        }
    }
}
