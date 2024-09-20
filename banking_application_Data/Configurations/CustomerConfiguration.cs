using banking_application_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banking_application_Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(c => c.LastName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(c => c.Email)
                   .HasMaxLength(255)
                   .IsRequired();
            builder.Property(c => c.Password)
                   .HasMaxLength(255)
                   .IsRequired();

        }
    }
}
