using banking_application_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banking_application_Data.Configurations
{
    public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            builder.ToTable("TransactionHistories");
            builder.HasKey(th => th.Id);
            builder.Property(th => th.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(th => th.TransactionDetails)
                   .HasMaxLength(500); 

            builder.Property(th => th.OperationTime)
                   .IsRequired();

            builder.HasOne(a => a.Account)
                   .WithMany(t => t.TransactionHistorys) 
                   .HasForeignKey(th => th.AccountId);
        }
    }
}
