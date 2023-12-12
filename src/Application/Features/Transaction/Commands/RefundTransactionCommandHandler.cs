using PaymentDemo.Application.Features.Transaction.BankStrategy;
using PaymentDemo.Application.Interfaces.Command;
using PaymentDemo.Application.Interfaces.Repository;
using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Transaction.Commands
{
    public sealed class RefundTransactionCommandHandler : ICommandHandler<RefundTransactionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankStrategyFactory _bankStrategyFactory;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionDetailRepository _transactionDetailRepository;


        public RefundTransactionCommandHandler(
            IUnitOfWork unitOfWork,
            IBankStrategyFactory bankStrategyFactory,
            ITransactionRepository transactionRepository,
            ITransactionDetailRepository transactionDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _bankStrategyFactory = bankStrategyFactory;
            _transactionRepository = transactionRepository;
            _transactionDetailRepository = transactionDetailRepository;
        }

        public async Task<Result> Handle(RefundTransactionCommand request, CancellationToken cancellationToken)
        {

            var transaction = await _transactionRepository.GetByIdWithDetailAsync(request.TransactionId);

            if (transaction == null)
                return Result.Failure(Error.NotFound);

            if ((DateTime.Now - transaction.TransactionDate).TotalDays < 1)
                return Result.Failure(Error.NotPassedOneDayTransaction);

            var bankStrategy = _bankStrategyFactory.CreateBankStrategy(transaction.BankId);

            var refundResult = bankStrategy.Refund(transaction);

            if (!refundResult.IsSuccess) return Result.Failure<Domain.Entities.Transaction>(Error.NotFound);

            try
            {
                var transactionDetail = new TransactionDetail
                {
                    TransactionType = TransactionType.Refund,
                    Amount = -transaction.NetAmount,
                    TransactionId = transaction.Id,
                };

                await _transactionDetailRepository.AddAsync(transactionDetail);
                transaction.NetAmount -= transaction.NetAmount * 1;
                await _unitOfWork.Commit(cancellationToken);

            }
            catch (Exception e)
            {
                await _unitOfWork.Rollback(cancellationToken);
                return Result.Failure<Domain.Entities.Transaction>(Error.Update);
            }

            return Result.Success(transaction);
        }
    }
}
