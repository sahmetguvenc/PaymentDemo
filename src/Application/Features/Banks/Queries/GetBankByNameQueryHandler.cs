using PaymentDemo.Application.Interfaces.Repository;

namespace PaymentDemo.Application.Features.Banks.Queries
{
    public class GetBankByNameQueryHandler : IRequestHandler<GetBankByNameQuery, Result<GetBankResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;

        public GetBankByNameQueryHandler(IMapper mapper, IBankRepository bankRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<Result<GetBankResponse>> Handle(GetBankByNameQuery query, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetByNameAsync(query.Name);
            return bank is null ? Result.Failure<GetBankResponse>(Error.NotFound)
                                : Result.Success(_mapper.Map<GetBankResponse>(bank));
        }
    }
}
