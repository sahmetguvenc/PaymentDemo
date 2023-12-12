namespace PaymentDemo.Infrastructure.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(PaymentDbContext context)
        {
            if (!await context.Banks.AnyAsync())
            {
                await context.Banks.AddRangeAsync(GetDefaultBanks());

                await context.SaveChangesAsync();
            }
        }
        static IEnumerable<Bank> GetDefaultBanks()
        {
            return new List<Bank>
            {
                new() { Id = 1, Name = "Akbank", IsActive = true, },
                new() { Id = 2, Name = "Garanti", IsActive = true, },
                new() { Id = 3, Name = "YapıKredi", IsActive = true, },
            };
        }
    }
}
