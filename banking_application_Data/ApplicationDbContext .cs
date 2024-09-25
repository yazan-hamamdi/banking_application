using banking_application_Data.Configurations;
using banking_application_Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace banking_application_Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        ////public ApplicationDbContext() { }
        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    if (!optionsBuilder.IsConfigured)
        ////    {
        ////        optionsBuilder.UseSqlServer("Server=DESKTOP-7FSOJ3K;Database=bank;Integrated Security=SSPI;TrustServerCertificate=True;");

        ////    }
        ////}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionHistoryConfiguration());
        }
    }
}