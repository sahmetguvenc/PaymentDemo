using PaymentDemo.Application.Interfaces.Command;
using PaymentDemo.Domain.Enums;

namespace PaymentDemo.Application.Features.Transaction.Commands
{

    public sealed record PayTransactionCommand(
             decimal TotalAmount,
             decimal NetAmount,
             TransactionStatus Status,
             long OrderReference,
             int BankId) : ICommand;
}
