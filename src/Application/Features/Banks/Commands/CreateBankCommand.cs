using PaymentDemo.Application.Interfaces.Command;

namespace PaymentDemo.Application.Features.Banks.Commands
{
    public sealed record CreateBankCommand(string Name, bool IsActive = true) : ICommand;
}
