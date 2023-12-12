namespace PaymentDemo.Application.Interfaces.Repository
{
    public interface IBankRepository
    {
        Task<Bank?> GetByIdAsync(int id);
        Task<Bank?> GetByNameAsync(string name);
        Task<Bank> AddAsync(Bank bank);
    }
}
