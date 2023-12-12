namespace PaymentDemo.Domain.Entities
{
    public class TransactionDetail : AuditableEntity, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public Guid TransactionId { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual Transaction Transaction { get; private set; }
    }
}
