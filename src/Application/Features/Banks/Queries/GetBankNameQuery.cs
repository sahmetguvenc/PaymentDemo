using PaymentDemo.Application.Interfaces.Query;

namespace PaymentDemo.Application.Features.Banks.Queries
{
    public sealed record GetBankByNameQuery(string Name) : IQuery<GetBankResponse>;
}
