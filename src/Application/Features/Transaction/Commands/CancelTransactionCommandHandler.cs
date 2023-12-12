using PaymentDemo.Application.Features.Transaction.BankStrategy;
using PaymentDemo.Application.Interfaces.Command;
using PaymentDemo.Application.Interfaces.Repository;
using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Transaction.Commands
{
    public sealed class CancelTransactionCommandHandler : ICommandHandler<CancelTransactionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankStrategyFactory _bankStrategyFactory;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionDetailRepository _transactionDetailRepository;

        public CancelTransactionCommandHandler(
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

        public async Task<Result> Handle(CancelTransactionCommand request, CancellationToken cancellationToken)
        {

            var transaction = await _transactionRepository.GetByIdWithDetailAsync(request.TransactionId);

            if (transaction == null)
                return Result.Failure(Error.NotFound);

            if (transaction.TransactionDate.Date != DateTime.Now.Date)
                return Result.Failure(Error.NotSameDayTransaction);

            var bankStrategy = _bankStrategyFactory.CreateBankStrategy(transaction.BankId);

            var cancelResult = bankStrategy.Cancel(transaction);

            if (!cancelResult.IsSuccess) return Result.Failure<Domain.Entities.Transaction>(Error.NotFound);

            try
            {
                var transactionDetail = new TransactionDetail
                {
                    TransactionType = TransactionType.Cancel,
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
