using System.Linq.Expressions;
using EFCoreSecondLevelCacheInterceptor;

namespace PaymentDemo.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PaymentDbContext _dbContext;
        private bool _cacheable;
        private bool _asNoTracking;
        private bool _asSplitQuery;

        public Repository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> GetDbSet()
        {
            return _dbContext.Set<T>();
        }

        private IQueryable<T> GetQueryable()
        {
            IQueryable<T> query = _cacheable ? GetDbSet().Cacheable() : GetDbSet();
            query = _asNoTracking ? query.AsNoTracking() : query;
            query = _asSplitQuery ? query.AsSplitQuery() : query;

            return query;
        }

        public IQueryable<T> FindAll()
        {
            return GetQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return FindAll().Where(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await GetDbSet().AddAsync(entity);
            return entity;
        }
       
    }
}
