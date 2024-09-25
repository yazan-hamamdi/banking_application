using banking_application_Data.IEntities;
using Microsoft.AspNetCore.Identity;

namespace banking_application_Data.Entities
{
    public class Customer : IdentityUser , ICustomer
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Account>? Accounts { get; set; } = new List<Account>();
    }
}
