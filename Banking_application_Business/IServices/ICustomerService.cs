using Banking_application_Business.DTOs;

namespace Banking_application_Business.IServices
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerWithoutId>> GetAllAsync();
        Task<CustomerWithoutId> GetByIdAsync(int id);
        Task<CustomerWithId> AddAsync(CustomerWithId customer);
        Task<CustomerWithoutId> UpdateAsync(CustomerWithId customer, int id);
        Task DeleteAsync(int id);
    }
}
