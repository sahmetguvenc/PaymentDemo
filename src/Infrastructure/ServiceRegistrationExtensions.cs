using Microsoft.Extensions.DependencyInjection;
using PaymentDemo.Infrastructure.Repository;

namespace PaymentDemo.Infrastructure
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionDetailRepository, TransactionDetailRepository>();
            services.AddDbContext<PaymentDbContext>(options => options.UseInMemoryDatabase("BankPaymentDB"));

            return services;
        }
    }
}
