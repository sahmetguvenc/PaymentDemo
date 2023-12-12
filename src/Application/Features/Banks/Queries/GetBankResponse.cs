namespace PaymentDemo.Application.Features.Banks.Queries
{
    public sealed class GetBankResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
