using PaymentDemo.Application.Interfaces.Query;
using PaymentDemo.Application.Interfaces.Repository;

namespace PaymentDemo.Application.Features.Report.Queries
{
    public class GetReportQueryHandler : IQueryHandler<ReportQuery, IReadOnlyList<ReportTransactionQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public GetReportQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Result<IReadOnlyList<ReportTransactionQueryResponse>>> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            var result = await _transactionRepository.GetTransactionWithDetailAsync(request);
            var mappedResult = _mapper.Map<IReadOnlyList<ReportTransactionQueryResponse>>(result);
            return Result.Success(mappedResult);
        }

    }
}
