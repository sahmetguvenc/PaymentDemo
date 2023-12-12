using System.Linq.Expressions;
namespace PaymentDemo.Application.Interfaces.Repository
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }

    public interface ICrudRepository<T> : IReadRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }

    public interface IRepository<T> : ICrudRepository<T> where T : class
    {

    }
}