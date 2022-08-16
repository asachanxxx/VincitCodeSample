using System;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Picklist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity)
        {
            entity.Property(e => e.ReconciliationFrequency).HasMaxLength(50)
                .HasConversion(
                    e => e == null ? null : e.Name,
                    e => e == null ? null : ReconciliationFrequencyEnum.FromName(e, true));
        }
    }
}
