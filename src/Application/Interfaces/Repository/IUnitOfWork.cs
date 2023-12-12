namespace PaymentDemo.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<int> Commit(CancellationToken cancellationToken);
        Task Rollback(CancellationToken cancellationToken);
    }
}
