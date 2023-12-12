using PaymentDemo.Application.Interfaces.Query;
using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Report.Queries
{
    public sealed record ReportQuery(
        int? BankId,
        TransactionStatus? Status,
        long? OrderReference,
        DateTime? StartDate,
        DateTime? EndDate) : IQuery<IReadOnlyList<ReportTransactionQueryResponse>>;
}
