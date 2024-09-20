using banking_application_Data.Entities;
using banking_application_Data.IEntities;

namespace banking_application_Data.IRepositories
{
    public interface IAccountRepo
    {
        Task<ICollection<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task<Account> AddAsync(Account account);
        Task<Account> UpdateAsync(Account account, int id);
        Task DeleteAsync(int id);
    }
}
