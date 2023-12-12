namespace PaymentDemo.Infrastructure.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly IRepository<Bank> _bankRepository;
        public BankRepository(IRepository<Bank> bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<Bank?> GetByIdAsync(int id)
        {
            return await _bankRepository.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Bank?> GetByNameAsync(string name)
        {
            return await _bankRepository.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<Bank> AddAsync(Bank bank)
        {
            return await _bankRepository.AddAsync(bank);
        }
    }
}
