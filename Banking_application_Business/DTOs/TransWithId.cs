

namespace Banking_application_Business.DTOs
{
    public class TransWithId
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionDetails { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
