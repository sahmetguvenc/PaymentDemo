using PaymentDemo.Application.Interfaces.Query;

namespace PaymentDemo.Application.Features.Banks.Queries
{
    public sealed record GetBankByIdQuery(int Id) : IQuery<GetBankResponse>;
}

