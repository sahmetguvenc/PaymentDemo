using PaymentDemo.Application.Interfaces.Command;
using PaymentDemo.Application.Interfaces.Repository;

namespace PaymentDemo.Application.Features.Banks.Commands
{
    public sealed class CreateBankCommandHandler : ICommandHandler<CreateBankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankRepository _bankRepository;

        public CreateBankCommandHandler(IUnitOfWork unitOfWork, IBankRepository bankRepository)
        {
            _unitOfWork = unitOfWork;
            _bankRepository = bankRepository;
        }

        public async Task<Result> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {

            var bank = new Bank
            {
                Name = request.Name,
                IsActive = request.IsActive,
            };
            await _bankRepository.AddAsync(bank);
            await _unitOfWork.Commit(cancellationToken);
            return Result.Success(bank);
        }
    }
}
