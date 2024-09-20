

namespace Banking_application_Business.DTOs
{
    public class TransWithoutId
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionDetails { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
