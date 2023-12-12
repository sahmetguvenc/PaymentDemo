namespace PaymentDemo.Domain.Entities
{
    public sealed class Transaction : AuditableEntity, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public TransactionStatus Status { get; set; }
        public long OrderReference { get; set; }
        public DateTime TransactionDate { get; set; }

        public int BankId { get; set; }
        public Bank? Bank { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
    }
}
