using PaymentDemo.Application.Features.Report.Queries;

namespace PaymentDemo.Application.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction transaction);
        Task<Transaction?> GetByIdWithDetailAsync(Guid id);
        Task<List<Transaction>> GetTransactionWithDetailAsync(ReportQuery reportQuery);
    }
}
