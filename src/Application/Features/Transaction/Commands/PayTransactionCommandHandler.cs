using PaymentDemo.Application.Features.Transaction.BankStrategy;
using PaymentDemo.Application.Interfaces.Command;
using PaymentDemo.Application.Interfaces.Repository;
using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Transaction.Commands
{
    public sealed class PayTransactionCommandHandler : ICommandHandler<PayTransactionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankStrategyFactory _bankStrategyFactory;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionDetailRepository _transactionDetailRepository;

        public PayTransactionCommandHandler(
            IUnitOfWork unitOfWork,
            IBankStrategyFactory bankStrategyFactory,
            IMapper mapper,
            ITransactionRepository transactionRepository,
            ITransactionDetailRepository transactionDetailRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _bankStrategyFactory = bankStrategyFactory;
            _transactionRepository = transactionRepository;
            _transactionDetailRepository = transactionDetailRepository;
        }

        public async Task<Result> Handle(PayTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Domain.Entities.Transaction>(request);

            var bankStrategy = _bankStrategyFactory.CreateBankStrategy(request.BankId);

            var payResult = bankStrategy.Pay(transaction);

            if (payResult.IsSuccess)
            {
                try
                {
                    await _transactionRepository.AddAsync(transaction);
                    var detail = new TransactionDetail
                    {
                        Amount = transaction.TotalAmount,
                        TransactionId = transaction.Id,
                        TransactionType = TransactionType.Sale,
                        Status = transaction.Status,
                    };
                    await _transactionDetailRepository.AddAsync(detail);
                    await _unitOfWork.Commit(cancellationToken);
                }
                catch (Exception e)
                {
                    await _unitOfWork.Rollback(cancellationToken);
                    return Result.Failure<Domain.Entities.Transaction>(Error.Insert);
                }

                return Result.Success(transaction);

            }

            return Result.Failure<Domain.Entities.Transaction>(Error.NotFound);
        }

    }

}