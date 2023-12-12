using PaymentDemo.Application.Interfaces.Command;

namespace PaymentDemo.Application.Features.Transaction.Commands
{
    public sealed record CancelTransactionCommand(Guid TransactionId) : ICommand;
}
