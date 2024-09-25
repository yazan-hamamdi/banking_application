using banking_application_Data.IEntities;

namespace banking_application_Data.Entities
{
    public class Account : IAccount
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Type { get; set; }
        public Customer Customer { get; set; }
        public ICollection<TransactionHistory>? TransactionHistorys { get; set; } = new List<TransactionHistory>();
    }
}
