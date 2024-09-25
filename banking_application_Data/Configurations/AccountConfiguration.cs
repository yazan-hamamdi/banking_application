using banking_application_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banking_application_Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Balance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(a => a.CreationDate)
                   .IsRequired();

            builder.Property(a => a.Type)
                   .HasMaxLength(50); 

            builder.HasOne(c => c.Customer)
                   .WithMany(a => a.Accounts)
                   .HasForeignKey(a => a.CustomerId);
        }
    }
}
