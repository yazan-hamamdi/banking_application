using banking_application_Data.Entities;
using banking_application_Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace banking_application_Data.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ApplicationDbContext _context;

        public AccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();  
            return account;
        }

        public async Task DeleteAsync(int id)
        {
            var accountToDelete = await _context.Accounts.FindAsync(id);
            if (accountToDelete != null)
            {
                _context.Accounts.Remove(accountToDelete);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<ICollection<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();  
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);  
        }

        public async Task<Account> UpdateAsync(Account updateAccount, int id)
        {
            if (updateAccount == null || id != updateAccount.Id)
            {
                return null; 
            }
            _context.Accounts.Update(updateAccount); 
            await _context.SaveChangesAsync(); 

            return updateAccount;
        }
    }
}
