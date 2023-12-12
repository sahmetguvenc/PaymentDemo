namespace PaymentDemo.Application.Interfaces.Query
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
           where TQuery : IQuery<TResponse>
    {
    }
}