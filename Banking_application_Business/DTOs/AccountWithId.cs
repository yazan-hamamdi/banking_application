

namespace Banking_application_Business.DTOs
{
     public class AccountWithId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Type { get; set; }
    }
}
