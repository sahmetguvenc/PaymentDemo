 
namespace PaymentDemo.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaymentDbContext _dbContext;

        public UnitOfWork(PaymentDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await Rollback(cancellationToken);
                throw;
            }
        }

        public async Task Rollback(CancellationToken cancellationToken)
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }

    }
}