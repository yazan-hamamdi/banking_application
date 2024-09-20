using Banking_application_Business.DTOs;

namespace Banking_application_Business.IServices
{
    public interface ITransactionHistoryService
    {
        Task<ICollection<TransWithoutId>> GetAllAsync();
        Task<TransWithoutId> GetByIdAsync(int id);
        Task<TransWithId> AddAsync(TransWithId transactionHistory);
        Task<TransWithoutId> UpdateAsync(TransWithId transactionHistory, int id);
        Task DeleteAsync(int id);
    }
}
