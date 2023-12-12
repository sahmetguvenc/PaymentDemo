namespace PaymentDemo.Application.Features.Transaction.BankStrategy
{
    public class GarantiStrategy : BankStrategy
    {
        public override Result Pay(Domain.Entities.Transaction transaction)
        {
            return base.Pay(transaction);
        }

        public override Result Cancel(Domain.Entities.Transaction transaction)
        {
            return base.Cancel(transaction);
        }

        public override Result Refund(Domain.Entities.Transaction transaction)
        {
            return base.Refund(transaction);
        }
    }
}
