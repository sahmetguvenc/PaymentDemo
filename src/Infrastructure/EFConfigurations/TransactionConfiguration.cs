using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentDemo.Infrastructure.EFConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(transaction => transaction.Bank)
                   .WithMany(bank => bank.Transactions)
                   .HasForeignKey(transaction => transaction.BankId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(transaction => transaction.Id);

            builder.HasIndex(t => t.BankId)
                   .IsUnique(false)
                   .HasDatabaseName("IX_Transaction_BankId");

            builder.HasIndex(t => t.OrderReference)
                   .IsUnique(false)
                   .HasDatabaseName("IX_Transaction_OrderReference");
        }
    }
}

