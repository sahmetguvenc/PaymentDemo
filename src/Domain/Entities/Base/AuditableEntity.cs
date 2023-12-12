namespace PaymentDemo.Domain.Entities.Base
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
