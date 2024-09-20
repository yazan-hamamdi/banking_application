using banking_application_Data.IEntities;

namespace banking_application_Data.Entities
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Account>? Accounts { get; set; } = new List<Account>();
        


    }
}
