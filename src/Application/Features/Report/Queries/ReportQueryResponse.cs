namespace PaymentDemo.Application.Features.Report.Queries
{
    public sealed class ReportTransactionQueryResponse
    {
        public int BankId { get; set; }
        public string? BankName { get; set; }
        public string? IsActiveBank { get; set; }
        public Guid TransactionId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string? Status { get; set; }
        public long OrderReference { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<ReportTransactionDetail> TransactionDetails { get; set; } = new();
    }

    public sealed class ReportTransactionDetail
    {
        public Guid TransactionDetailId { get; set; }
        public string? Status { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }
    }
}
