

namespace banking_application_Data.IEntities
{
    public interface IAccount
    {
        int Id { get; set; }
        int UserId { get; set; }
        decimal Balance { get; set; }
        DateTime CreationDate { get; set; }
        string? Type { get; set; }
    }
}
