using banking_application_Data.IEntities;

namespace banking_application_Data.Entities
{
    public class TransactionHistory : ITransactionHistory
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionDetails { get; set; }
        public DateTime OperationTime { get; set; }
        public Account Account { get; set; }
    }
}
