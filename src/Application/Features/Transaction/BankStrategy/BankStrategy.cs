using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Transaction.BankStrategy
{
    public abstract class BankStrategy
    {
        public virtual Result Pay(Domain.Entities.Transaction transaction)
        {
            transaction.TransactionDate = DateTime.Now;
            // other business logics
            return Result.Success();
        }

        public virtual Result Cancel(Domain.Entities.Transaction transaction)
        {
            return IsValidTransactionDetail(transaction) ? Result.Success()
                                                         : Result.Failure(Error.NullValue);
        }

        public virtual Result Refund(Domain.Entities.Transaction transaction)
        {
            return IsValidTransactionDetail(transaction) ? Result.Success()
                                                         : Result.Failure(Error.NullValue);
        }

        private bool IsValidTransactionDetail(Domain.Entities.Transaction transaction)
        {
            var detail = transaction.TransactionDetails.FirstOrDefault(x => x is { Status: TransactionStatus.Success, TransactionType: TransactionType.Sale });
            return detail != null;
        }

    }
}
