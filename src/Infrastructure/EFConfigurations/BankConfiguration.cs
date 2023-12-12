using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentDemo.Infrastructure.EFConfigurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(128);
        }
    }
}
