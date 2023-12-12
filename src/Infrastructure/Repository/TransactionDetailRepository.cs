namespace PaymentDemo.Infrastructure.Repository
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {

        private readonly IRepository<TransactionDetail> _transactionDetailRepository;

        public TransactionDetailRepository(IRepository<TransactionDetail> transactionDetailRepository)
        {
            _transactionDetailRepository = transactionDetailRepository;
        }

        public async Task<TransactionDetail> AddAsync(TransactionDetail transactionDetail)
        {
            return await _transactionDetailRepository.AddAsync(transactionDetail);
        }

    }
}
