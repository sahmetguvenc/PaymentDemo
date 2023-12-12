namespace PaymentDemo.Application.Interfaces
{
    public interface IPaymentDbContext
    {
        DbSet<Bank> Banks { get; }
        DbSet<Transaction> Transactions { get; }
        DbSet<TransactionDetail> TransactionDetails { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
