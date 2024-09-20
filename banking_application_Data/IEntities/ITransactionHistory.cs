
namespace banking_application_Data.IEntities
{
    public interface ITransactionHistory
    {
        int Id { get; set; }
        int AccountId { get; set; }
        decimal Amount { get; set; }
        string? TransactionDetails { get; set; }
        DateTime OperationTime { get; set; }
    }
}
