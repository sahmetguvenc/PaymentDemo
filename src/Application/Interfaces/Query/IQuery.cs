namespace PaymentDemo.Application.Interfaces.Query
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
