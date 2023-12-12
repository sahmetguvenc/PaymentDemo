using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentDemo.Infrastructure.EFConfigurations
{
    public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
    {
        public void Configure(EntityTypeBuilder<TransactionDetail> builder)
        {
            builder.HasOne(transactionDetail => transactionDetail.Transaction)
                   .WithMany(transaction => transaction.TransactionDetails)
                   .HasForeignKey(transactionDetail => transactionDetail.TransactionId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(transactionDetail => transactionDetail.Id);

            builder.HasIndex(transactionDetail => transactionDetail.TransactionId)
                   .IsUnique(false)
                   .HasDatabaseName("IX_TransactionDetail_TransactionId");
        }
    }
}
