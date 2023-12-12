using PaymentDemo.Application.Features.Report.Queries;
using PaymentDemo.Application.Features.Transaction.Commands;

namespace PaymentDemo.Application.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<PayTransactionCommand, Transaction>().ReverseMap();
            CreateMap<TransactionDetail, ReportTransactionDetail>();
            CreateMap<Transaction, ReportTransactionQueryResponse>();
        }

    }
}
