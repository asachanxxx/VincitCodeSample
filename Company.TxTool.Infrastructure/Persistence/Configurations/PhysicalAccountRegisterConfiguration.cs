using System;
using Cushwake.TreasuryTool.Domain.AccountOpenRequest;
using Cushwake.TreasuryTool.Domain.AccountRegister;
using Cushwake.TreasuryTool.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence.Configurations
{
    public class PhysicalAccountRegisterConfiguration : IEntityTypeConfiguration<PhysicalAccountRegister>
    {
        public void Configure(EntityTypeBuilder<PhysicalAccountRegister> entity)
        {
            entity.Property(e => e.ClientRef).HasMaxLength(50);
            entity.Property(e => e.PropertyName);
            entity.Property(e => e.PrefferedCashbookID);
            entity.Property(e => e.TenancyReferenceNumber);
            entity.Property(e => e.PayingInBooksToGoTo);
            entity.Property(e => e.SortCode);
            entity.Property(e => e.AccountNumber);
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
               .HasConstraintName("FK_AccountRegister_AccountTypeID");

            entity.HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(m => m.CurrencyID)
                .HasConstraintName("FK_AccountRegister_CurrencyID");

            entity.HasOne(e => e.BankReconciliationsToBePreparedByUser)
                .WithMany()
                .HasForeignKey(m => m.BankReconciliationsToBePreparedById)
                .HasConstraintName("FK_AccountRegister_BankReconciliationsToBePreparedById");

            entity.HasOne(e => e.BankReconciliationsToBeReviewedByUser)
                .WithMany()
                .HasForeignKey(m => m.BankReconciliationsToBeReviewedById)
                .HasConstraintName("FK_AccountRegister_BankReconciliationsToBeReviewedById");
        }
    }
}