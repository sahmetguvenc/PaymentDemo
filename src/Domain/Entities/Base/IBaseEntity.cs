namespace PaymentDemo.Domain.Entities.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
