using PaymentDemo.Domain.Enums;
using PaymentDemo.Application.Extensions;

namespace PaymentDemo.Application.Features.Transaction.BankStrategy
{
    public interface IBankStrategyFactory
    {
        BankStrategy CreateBankStrategy(int bankId);
    }

    public class BankStrategyFactory : IBankStrategyFactory
    {
        public BankStrategy CreateBankStrategy(int bankId)
        {
            var bankType = bankId.GetEnum<BankType>();

            return bankType switch
            {
                BankType.Akbank => new AkBankStrategy(),
                BankType.Garanti => new GarantiStrategy(),
                BankType.YapiKredi => new YapiKrediStrategy(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
