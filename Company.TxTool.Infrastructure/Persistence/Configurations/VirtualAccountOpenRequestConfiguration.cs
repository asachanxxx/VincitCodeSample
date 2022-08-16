using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class VirtualAccountOpenRequestConfiguration : IEntityTypeConfiguration<VirtualAccountOpenRequest>
    {
        public void Configure(EntityTypeBuilder<VirtualAccountOpenRequest> entity)
        {
            entity.Property(e => e.ClientRef).HasMaxLength(50);
            entity.Property(e => e.PropertyName);
            entity.Property(e => e.PrefferedCashbookID);
            entity.Property(e => e.TenancyReferenceNumber);
            entity.Property(e => e.TrampsCashbookId);
            entity.Property(e => e.BankRe1);
            entity.Property(e => e.BankRe2);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.AmountOfOpeninigBalanceMovedToAccount).HasPrecision(18, 2);
            entity.Property(e => e.RejectReason);
            entity.Property(e => e.DepositLetterTenantRef);

            entity.HasOne(e => e.AccountType)
                .WithMany()
                .HasForeignKey(m => m.AccountTypeID)
                .HasConstraintName("FK_AccountOpenRequest_AccountTypeID");

            entity.HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(m => m.CurrencyID)
                .HasConstraintName("FK_AccountOpenRequest_CurrencyID");

            entity.HasOne(e => e.BankReconciliationsToBePreparedByUser)
                .WithMany()
                .HasForeignKey(m => m.BankReconciliationsToBePreparedById)
                .HasConstraintName("FK_AccountOpenRequest_BankReconciliationsToBePreparedById");

            entity.HasOne(e => e.BankReconciliationsToBeReviewedByUser)
                .WithMany()
                .HasForeignKey(m => m.BankReconciliationsToBeReviewedById)
                .HasConstraintName("FK_AccountOpenRequest_BankReconciliationsToBeReviewedById");
        }
    }
}
