using banking_application_Data.Entities;
using banking_application_Data.IEntities;

namespace banking_application_Data.IRepositories
{
    public interface ITransactionHistoryRepo
    {
        Task<ICollection<TransactionHistory>> GetAllAsync();
        Task<TransactionHistory> GetByIdAsync(int id);
        Task<TransactionHistory> AddAsync(TransactionHistory transactionHistory);
        Task<TransactionHistory> UpdateAsync(TransactionHistory transactionHistory, int id);
        Task DeleteAsync(int id);
    }
}
