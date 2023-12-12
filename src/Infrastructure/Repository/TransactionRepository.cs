using PaymentDemo.Application.Features.Report.Queries;

namespace PaymentDemo.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionRepository(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            return await _transactionRepository.AddAsync(transaction);
        }

        public async Task<Transaction?> GetByIdWithDetailAsync(Guid id)
        {
            return await _transactionRepository.Where(x => x.Id == id).Include("TransactionDetails").FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactionWithDetailAsync(ReportQuery reportQuery)
        {
            var query = _transactionRepository.FindAll().Include("TransactionDetails");
            if (reportQuery.BankId.HasValue)
                query = query.Where(t => t.BankId == reportQuery.BankId);

            if (reportQuery.Status.HasValue)
                query = query.Where(t => t.Status == reportQuery.Status.Value);

            if (reportQuery.OrderReference.HasValue)
                query = query.Where(t => t.OrderReference == reportQuery.OrderReference.Value);

            if (reportQuery.StartDate.HasValue)
                query = query.Where(t => t.TransactionDate >= reportQuery.StartDate.Value);

            if (reportQuery.EndDate.HasValue)
                query = query.Where(t => t.TransactionDate <= reportQuery.EndDate.Value);

            return await query.ToListAsync();
        }

    }
}