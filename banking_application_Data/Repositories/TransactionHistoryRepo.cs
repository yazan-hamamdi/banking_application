using banking_application_Data.Entities;
using banking_application_Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace banking_application_Data.Repositories
{
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private readonly ApplicationDbContext _context;

        public TransactionHistoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionHistory> AddAsync(TransactionHistory transaction)
        {
            await _context.TransactionHistories.AddAsync(transaction);
            await _context.SaveChangesAsync(); 
            return transaction;
        }

        public async Task DeleteAsync(int id)
        {
            var transactionToDelete = await _context.TransactionHistories.FindAsync(id); 
            if (transactionToDelete != null)
            {
                _context.TransactionHistories.Remove(transactionToDelete); 
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task<ICollection<TransactionHistory>> GetAllAsync()
        {
            return await _context.TransactionHistories.ToListAsync(); 
        }

        public async Task<TransactionHistory> GetByIdAsync(int id)
        {
            return await _context.TransactionHistories.FindAsync(id); 
        }

        public async Task<TransactionHistory> UpdateAsync(TransactionHistory updatedTransaction, int id)
        {
            if (updatedTransaction == null || id != updatedTransaction.Id)
            {
                return null; 
            }
            _context.TransactionHistories.Update(updatedTransaction); 
            await _context.SaveChangesAsync(); 

            return updatedTransaction;
        }

    }
}
