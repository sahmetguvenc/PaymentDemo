using PaymentDemo.Application.Interfaces.Query;
using PaymentDemo.Application.Interfaces.Repository;

namespace PaymentDemo.Application.Features.Banks.Queries
{
    public sealed class GetBankByIdQueryHandler : IQueryHandler<GetBankByIdQuery, GetBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;

        public GetBankByIdQueryHandler(IMapper mapper, IBankRepository bankRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<Result<GetBankResponse>> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetByIdAsync(request.Id);

            return bank is null ? Result.Failure<GetBankResponse>(Error.NotFound)
                                : Result.Success(_mapper.Map<GetBankResponse>(bank));
        }
    }
}
