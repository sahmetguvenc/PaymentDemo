namespace PaymentDemo.Domain.Entities
{
    public class Bank : AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
