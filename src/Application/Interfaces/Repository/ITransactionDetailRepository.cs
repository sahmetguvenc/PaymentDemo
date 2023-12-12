
namespace PaymentDemo.Application.Interfaces.Repository
{
    public interface ITransactionDetailRepository
    {
        Task<TransactionDetail> AddAsync(TransactionDetail transaction);
    }
}
