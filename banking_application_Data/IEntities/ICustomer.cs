
namespace banking_application_Data.IEntities
{
    public interface ICustomer
    {
        int Id { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? Email { get; set; }
        string? Password { get; set; }
    }
}
