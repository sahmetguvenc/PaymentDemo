using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using PaymentDemo.Application.Features.Transaction.BankStrategy;

namespace PaymentDemo.Application
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBankStrategyFactory, BankStrategyFactory>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });
            return services;
        }
    }
}
